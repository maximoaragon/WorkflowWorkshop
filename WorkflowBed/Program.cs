using System;
using System.Collections.Generic;
using System.IO;

namespace WorkflowBed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("**********Workflow Bed************");

            ////////////////////
            //TODO: SET THE PATH OF THE WORKFLOW TO INVOKE. THIS WILL BE EITHER A XAML OR XOML FILE
            //////////////////

            //string workflowFilePath = @"..\..\..\WorkflowLib\DES\SimpleDESWorkflow.xaml";
            string workflowFilePath = @"..\..\..\WorkflowLib\Redwood\RedwoodExchangeWorkflow.xaml";
            //string workflowFilePath = @"..\..\..\WorkflowLib\Redwood\RedwoodFileWorkflow.xaml";

            //******************************DES workflow parameters*******************************
            var param = new Dictionary<string, string>()
            {
                  { "USER", "testusr" } ,//key must use UPPER CASE
                  { "PWD", "sh0wcas3" }//key must use UPPER CASE
            };

            var result = WorkflowUtil.RunDESWorkflow(workflowFilePath, param);

            //************************************************************************************


            //****************************ShowCase workflow parameters****************************

            //var param = new object[]
            //{
            //    "First Argument Value",
            //    "Second Argument Value"
            //};
            //WorkflowUtil.RunShowCaseWorkflow(workflowFilePath, "50-2015-CC-025987-XXXX-MB", param);

            //************************************************************************************

            Console.WriteLine("**********Workflow {0} Ended************", Path.GetFileName(workflowFilePath));
            Console.ReadLine();
        }
    }
}