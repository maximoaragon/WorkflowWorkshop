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

            //string workflowFilePath = @"..\..\..\WorkflowLib\Training\DESDemoWorkflow.xaml";
            string workflowFilePath = @"..\..\..\WorkflowLib\Templates\DESWorfklow.xaml";

            //******************************DES workflow parameters*******************************
            var parameters = new Dictionary<string, string>()
            {
                  { "casenumber", "2013cf123" } 
                  //{ "PWD", "sh0wcas3" }
            };

            //run des workflow
            var result = WorkflowUtil.RunDESWorkflow(workflowFilePath, parameters);

            //************************************************************************************

            //****************************ShowCase workflow parameters****************************

            //var parameters = new object[]
            //{
            //    "First Argument Value",
            //    "Second Argument Value"
            //};
            //run showcase workflow
            //WorkflowUtil.RunShowCaseWorkflow(workflowFilePath, "50-2015-CC-025987-XXXX-MB", parameters);

            //************************************************************************************

            Console.WriteLine("**********THE END************");
            Console.ReadLine();
        }
    }
}