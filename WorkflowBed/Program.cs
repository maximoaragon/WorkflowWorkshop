using CustomCodeWorkflow;
using Exchange.Contracts;
using System;
using System.Collections.Generic;

namespace WorkflowBed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("********Workflow Workshop*********");
           
            //RunXAMLWorkflow();

            //or 

            RunCodeWorkflow();

            Console.WriteLine("************THE END***************");
            Console.ReadLine();
        }

        static void RunCodeWorkflow()
        {
            //your class must implement Exchange.Contracts.IDataExchangeWorkflow
            IDataExchangeWorkflow codeWorkflow = new MyCodeWorkflow();

            var request = new ExchangeRequest()
            {
                RequestID = Guid.NewGuid().ToString()
            };

            //DES will the Run() function implemented
            string result = codeWorkflow.Run(request);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCode Workflow Result: {0}\n", result);
            Console.ResetColor();
        }

        static void RunXAMLWorkflow()
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

            var response = WorkflowUtil.ExecWorkflow(workflowFilePath, exchangeParams);
        }
    }
}