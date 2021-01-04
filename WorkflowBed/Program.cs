using System;
using System.Collections.Generic;

namespace WorkflowBed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("**********Workflow Bed************");
           
            RunTestWorkflow();

            Console.WriteLine("**********THE END************");
            Console.ReadLine();
        }

        static void RunTestWorkflow()
        {
            //1. Set the path of the XAML workflow to invoke.

            string workflowFilePath = @"..\..\..\WorkflowLib\Training\TestWorkflow.xaml";

            //2. Optionally add any parameters required by the workflow

            var exchangeParams = new Dictionary<string, string>()
            {
               { "NAME", "Max" }
            };

            //3. Call ExecWorkflow or ExecWorkflowInDES if connected to a DES database.

            //var response = WorkflowUtil.ExecWorkflowInDES(workflowFilePath, exchangeParams);

            WorkflowUtil.ExecWorkflow(workflowFilePath, exchangeParams);
        }
    }
}