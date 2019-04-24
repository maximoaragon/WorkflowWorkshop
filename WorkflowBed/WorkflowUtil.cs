using Exchange.Contracts;
using ShowCaseClassLib;
using ShowCaseClassLib.AuthenticationService;
using ShowCaseWorkflowLib;
using System;
using System.Activities;
using System.Activities.XamlIntegration;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xaml;
using System.Xml;

namespace WorkflowBed
{
    public static class WorkflowUtil
    {
        static ConsoleColor _ogColor = Console.ForegroundColor;

        public static void RunShowCaseWorkflow(string workflowFilePath, string caseNumber, object[] parms)
        {
            Console.WriteLine("running ShowCase workflow...", Path.GetFileName(workflowFilePath));

            //TODO: SET CASE PASSED TO THE WORKFLOW. THIS IS REQURED BY ANY SHOWCASE WORKFLOW.
            CCase testingCase = GetCaseObject(caseNumber);

            //This runs the workflow
            RunWorkflow(workflowFilePath, parms, testingCase);
        }

        public static XmlDocument RunDESWorkflow(string workflowFilePath, Dictionary<string, string> parameters)
        {
            Console.WriteLine("*Running DES workflow {0}...", Path.GetFileName(workflowFilePath));

            if (!File.Exists(workflowFilePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Workflow file not found!  :-(");
                Console.ForegroundColor = _ogColor;
                return null;
            }

            var exchangeRequest = new ExchangeRequest()
            {
                ExchangeName = "TestExchangeName",
                ProcessingMode = ProcessingMode.RealTime,
                ExchangeParameters = GetExchangeParameters(parameters)
            };

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("ExchangeRequest", exchangeRequest);

            string workflowDef;
            using (var xmlFile = XmlReader.Create(workflowFilePath))
            {
                StringBuilder sb = new StringBuilder();
                while (xmlFile.Read())
                    sb.AppendLine(xmlFile.ReadOuterXml());

                workflowDef = sb.ToString();
            }

            ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings() { CompileExpressions = true };
            using (var xamlReader = new XamlXmlReader(workflowFilePath))
            {
                using (var innerReader = ActivityXamlServices.CreateReader(xamlReader))
                {
                    Activity activity = ActivityXamlServices.Load(innerReader, settings);
                    var wfManager = new WorkflowInvoker(activity);

                    var wfresult = wfManager.Invoke(dict);
                    XmlDocument xmlResult = null;

                    Console.WriteLine("*Success :-)");

                    if (wfresult != null && wfresult.ContainsKey("Result"))
                    {
                        Console.WriteLine("*Result:");
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        xmlResult = (XmlDocument)wfresult["Result"];

                        Console.WriteLine(xmlResult?.OuterXml + "\n");

                        Console.ForegroundColor = _ogColor;
                    }

                    return xmlResult;
                }      
            }
        }

        private static Dictionary<string, string> GetExchangeParameters(Dictionary<string, string> parameters)
        {
            var ep = new Dictionary<string, string>();

            foreach (var kv in parameters)
                ep.Add(kv.Key.ToUpper(), kv.Value);

            return ep;
        }

        /// <summary>
        /// This method runs a workflow in the same way ShowCase does.
        /// </summary>
        /// <param name="workflowName"></param>
        /// <param name="parms"></param>
        static Dictionary<string, object> RunWorkflow(string workflowFilePath, object[] wfparms, CCase myCase)
        {
            bool isActivity = false;

            string def = "";
            string rules = "";
            Dictionary<string, object> workflowResult = null;
            XmlReader xmlFile = null; 

            try
            {
                xmlFile = XmlReader.Create(workflowFilePath);
                StringBuilder sb = new StringBuilder();
                while (xmlFile.Read())
                    sb.AppendLine(xmlFile.ReadOuterXml());

                def = sb.ToString();

                if (def.Trim().StartsWith("<Activity"))
                    isActivity = true;
                

                ArrayList aParam = new ArrayList(wfparms);

                if (isActivity)
                {
                    //This runs the XAML workflows
                    var wfManager = new ActivityRuntimeManager(myCase);
                    workflowResult  = wfManager.ExecuteXAMLActivity(def, aParam);
                }
                else
                {
                    //DEPRECATED WORKFLOWS
                    var xomlParam = new Dictionary<string, object>();
                    xomlParam.Add("Case", myCase);
                    xomlParam.Add("ParameterValues", aParam);

                    var rulesFileName = Path.GetDirectoryName(workflowFilePath) + "\\" + Path.GetFileNameWithoutExtension(workflowFilePath) + ".rules";

                    if (File.Exists(rulesFileName))
                    {
                        xmlFile = XmlReader.Create(rulesFileName);
                        sb = new StringBuilder();
                        while (xmlFile.Read())
                            sb.AppendLine(xmlFile.ReadOuterXml());
                        rules = sb.ToString();
                    }

                    //This runs the XOML workflows
                    var wfManager = new WorkflowManager();
                    wfManager.ExecuteXOMLWorkflow(def, rules, xomlParam);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in {0} workflow. {1}", Path.GetFileName(workflowFilePath), ex.ToString());
            }
            finally
            {
                if (xmlFile != null)
                    xmlFile.Dispose();
            }

            return workflowResult;
        }

        /// <summary>
        /// This method runs the workflow allowing to debug it. 
        /// </summary>
        /// <param name="workflowName"></param>
        /// <param name="parms"></param>
        static void RunAndDebugWorkflow(string workflowName, Dictionary<string, object> parms)
        {
            //WorkflowInvoker.Invoke(workflowName);
            var wfManager = new WorkflowManager();

            string def = "";
            string rules = "";

            wfManager.ExecuteXOMLWorkflow(def, rules, parms);
        }

        static CCase GetCaseObject(string caseNumber)
        {
            CCase myCase;

            if (!AuthenticateInShowCase())
                return null;

            try
            {
                int CaseID = 0;

                myCase = ShowCaseDAL.CCaseHelper.GetShellCase(CGlobal.eShowCaseDLLUsage.Other);
                myCase.GlobalClass().LoginID = ShowCaseDAL.CCaseHelper.GetLoginID();

                CaseID = myCase.GetCaseIDByCaseNumber(caseNumber);

                if (CaseID > 0)
                    myCase.Load(CaseID, false, true, true);
                else
                    throw new Exception("Case '" + caseNumber + "' was not found");

                return myCase;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading a Case object.\n{0}", ex.ToString());
                return null;
            }
        }

        static bool AuthenticateInShowCase()
        {
            try
            {
                string username = ConfigurationManager.AppSettings["UserName"];
                string password = ConfigurationManager.AppSettings["Password"];

                AuthenticationServiceClient authClient = new AuthenticationServiceClient("WSHttpBinding_IAuthenticationService");

                Dictionary<string, string> additionalCredentials = new Dictionary<string, string>();
                string sConn = ConfigurationManager.AppSettings["FriendlyDBName"];

                

                additionalCredentials.Add("friendlydbname", sConn);
                Security.Authentication.AuthenticationResponse authenticationResponse = authClient.AuthenticateUser(username, password, additionalCredentials);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error authenticating in ShowCase.\n{0}", ex.ToString());
                return false;
            }
        }

    }
}
