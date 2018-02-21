using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections;
using ShowCaseClassLib;
using System.IO;
using System.Xml;
using ShowCaseWorkflowLib;
using System.Text;
using System.Configuration;
using ShowCaseClassLib.AuthenticationService;

namespace WorkflowBed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("**********Workflow Bed************");

            //TODO: SET THE PATH OF THE WORKFLOW TO INVOKE. THIS WILL BE EITHER A XAML OR XOML FILE
            //string workflowFilePath = @"C:\Users\maxuel.aragones\Desktop\WorkflowWorkhop\WorkflowLib\Workflow1.xaml";
            string workflowFilePath = @"C:\Users\maxuel.aragones\Desktop\WorkflowWorkhop\WorkflowWorkhop\WorkflowLib\Duval Workflows\CreateCaseWorkflow.xoml";

            //TODO: SET CASE PASSED TO THE WORKFLOW. THIS IS REQURED BY ANY SHOWCASE WORKFLOW.
            CCase testingCase = GetCaseObject("50-2011-CA-009997-XXXX-WB");

            //TODO: OPTINALLY add any arguments required by the workflow 
            var parms = new object[]
            {
                "First Argument Value",
                "Second Argument Value"
            };

            //This runs the workflow
            RunWorkflow(workflowFilePath, parms, testingCase);

            Console.WriteLine("**********Workflow {0} Ended************", Path.GetFileName(workflowFilePath));
            Console.ReadLine();
        }

        #region "Core functions"

        /// <summary>
        /// This method runs a workflow in the same way ShowCase does.
        /// </summary>
        /// <param name="workflowName"></param>
        /// <param name="parms"></param>
        static void RunWorkflow(string workflowFilePath, object[] wfparms, CCase myCase)
        {
            bool isActivity = false;

            string def = "";
            string rules = "";

            try
            {
                XmlReader xmlFile = XmlReader.Create(workflowFilePath);
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
                    wfManager.ExecuteXAMLActivity(def, aParam);
                }
                else
                {
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
                    wfManager.ExecuteWorkflow(def, rules, xomlParam);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in {0} workflow. {1}", Path.GetFileName(workflowFilePath), ex.ToString());
            }
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

            wfManager.ExecuteWorkflow(def, rules, parms);
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

        #endregion
    }
}