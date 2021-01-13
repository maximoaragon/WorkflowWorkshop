using Exchange.Contracts;
using Exchange.ServerLib;
using System;
using System.Activities;
using System.Activities.XamlIntegration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xaml;
using System.Xml;

namespace WorkflowBed
{
    public static class WorkflowUtil
    {
        static ConsoleColor _ogColor = Console.ForegroundColor;

        /// <summary>
        /// Executes a XAML workflow in the DES context. This requires a DES <connectionStrings> configured in the app.config.
        /// </summary>
        /// <param name="workflowPath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static ExchangeResponse ExecWorkflowInDES(string workflowPath, Dictionary<string, string> parameters)
        {
            if (!IsWFPathValid(workflowPath))
                return null;

            //Create an ExchangeRequest that models the real DES web request
            ExchangeRequest request = new ExchangeRequest()
            {
                ExchangeID = 9999,
                RequestID = Guid.NewGuid().ToString(),
                ExchangeName = "Hello DES",
                ProcessingMode = ProcessingMode.NonRealTime, // required for test
                                                             //TODO: 2. Add any parameter required by the workflow. These come from the url query string, segment or exchange setting.
                ExchangeParameters = parameters
            };

            var wfMgr = new WorkflowManager();

            wfMgr.LoadFromPath(workflowPath);

            var ep = new Exchange.ServerLib.ExchangePoint(true, wfMgr);

            Console.Write("\nExecuting workflow {0} in DES...", Path.GetFileName(workflowPath));

            var response = ep.PerformAsyncDataExchange(request);
            Console.WriteLine("Done!\n");

            Console.WriteLine("DES Response:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n{0}\n", response.ToString());
            Console.ForegroundColor = _ogColor;

            return response;
        }

        /// <summary>
        /// Executes a XAML workflow as a stand-alone. Unlike ExecWorkflowInDES, this does not requires a DES <connectionStrings> configured.
        /// </summary>
        /// <param name="workflowPath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static XmlDocument ExecWorkflow(string workflowPath, Dictionary<string, string> parameters)
        {
            if (!IsWFPathValid(workflowPath))
                return null;

            var exchangeRequest = new ExchangeRequest()
            {
                ExchangeName = "TestExchangeName",
                ProcessingMode = ProcessingMode.RealTime,
                ExchangeParameters = GetExchangeParameters(parameters)
            };

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("ExchangeRequest", exchangeRequest);

            XmlDocument xmlResult = null;

            string workflowDef;
            using (var xmlFile = XmlReader.Create(workflowPath))
            {
                StringBuilder sb = new StringBuilder();
                while (xmlFile.Read())
                    sb.AppendLine(xmlFile.ReadOuterXml());

                workflowDef = sb.ToString();
            }

            ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings() { CompileExpressions = true };
            using (var xamlReader = new XamlXmlReader(workflowPath))
            {
                using (var innerReader = ActivityXamlServices.CreateReader(xamlReader))
                {
                    Activity activity = ActivityXamlServices.Load(innerReader, settings);

                    var wfinstance = new WorkflowApplication(activity, dict);

                    Console.Write("\nExecuting workflow {0}...", Path.GetFileName(workflowPath));

                    IDictionary<string, object> wfresult = null;

                    try
                    {
                        using(var syncEvent = new AutoResetEvent(false))
                        {
                            wfinstance.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\nWorkflow Error in Activity: {0}\n", e.ExceptionSource.DisplayName);
                                Console.WriteLine("{0}\n", e.UnhandledException.ToString());
                                Console.ForegroundColor = _ogColor;
                                return UnhandledExceptionAction.Terminate;
                            };

                            wfinstance.Aborted = delegate (WorkflowApplicationAbortedEventArgs e)
                            {
                                syncEvent.Set();
                            };

                            wfinstance.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
                            {
                                wfresult = e.Outputs;
                                syncEvent.Set();
                            };

                            wfinstance.Run(TimeSpan.MaxValue);

                            syncEvent.WaitOne();
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("\nWorkflow Error: {0}!\n", ex.Message);
                    }

                    Console.WriteLine("Done!\n");

                    if (wfresult != null && wfresult.ContainsKey("Result"))
                    {
                        Console.WriteLine("Workflow Response:\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        xmlResult = (XmlDocument)wfresult["Result"];
                        Console.WriteLine(xmlResult?.OuterXml + "\n");
                        Console.ForegroundColor = _ogColor;
                    }

                    return xmlResult;
                }      
            }
        }

        private static bool IsWFPathValid(string workflowPath)
        {
            if (!File.Exists(workflowPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Workflow file not found! :-(");
                Console.ForegroundColor = _ogColor;
                return false;
            }
            return true;
        }

        private static Dictionary<string, string> GetExchangeParameters(Dictionary<string, string> parameters)
        {
            var ep = new Dictionary<string, string>();

            foreach (var kv in parameters)
                ep.Add(kv.Key.ToUpper(), kv.Value);

            return ep;
        }
    }
}
