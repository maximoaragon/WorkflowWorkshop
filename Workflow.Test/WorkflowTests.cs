using Exchange.Contracts;
using Exchange.ServerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Workflow.Test
{
    [TestClass]
    public class WorkflowTests : TestBase
    {
        private string _workflowRootDir = "";

        [TestInitialize]
        public void Init()
        {
            _workflowRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\TestResults", "\\WorkflowLib");
            //should be something like C:\Dev\repos\WorkflowWorkshop\WorkflowLib...
        }

        [TestMethod]
        public void SimpleDESExchange()
        {
            //Mock exchange
            ExchangeRequest request = new ExchangeRequest()
            {
                ExchangeID = 9999,
                RequestID = Guid.NewGuid().ToString(),
                ExchangeName = "Simple Hello DES",
                ExchangeParameters = new Dictionary<string, string>() {
                    { "MYNAME", "Max" }
                },
                //InputUri = "https://showcase.equivant.com/eps/exchangePointservice.svc/...",
                ProcessingMode = ProcessingMode.NonRealTime // required for test
            };

            //Load workflow to be tested
            var wfMgr = new WorkflowManager();
            wfMgr.LoadFromPath(_workflowRootDir + @"\DES\SimpleDESExchange.xaml");

            var ep = new Exchange.ServerLib.ExchangePoint(true, wfMgr);

            var response = ep.PerformAsyncDataExchange(request);

            Assert.IsNotNull(response);

            Console.WriteLine($"RequestID: {response.RequestID}");

            Assert.IsNotNull(response.Result);

            Console.WriteLine($"Response: { response.Result.SelectSingleNode("data")?.InnerText}");
        }

        [TestMethod]
        public void FTPExchange()
        {
            //Mock exchange
            ExchangeRequest request = new ExchangeRequest()
            {
                ExchangeID = 9999,
                RequestID = Guid.NewGuid().ToString(),
                ExchangeName = "FTP Download",
         
                //InputUri = "https://showcase.equivant.com/eps/exchangePointservice.svc/...",
                ProcessingMode = ProcessingMode.NonRealTime // required for test
            };

            //Load workflow to be tested
            var wfMgr = new WorkflowManager();
            wfMgr.LoadFromPath(_workflowRootDir + @"\DES\FTPExampleWorkflow.xaml");

            var ep = new Exchange.ServerLib.ExchangePoint(true, wfMgr);

            var response = ep.PerformAsyncDataExchange(request);

            Assert.IsNotNull(response);

            Console.WriteLine($"RequestID: {response.RequestID}");

            Assert.IsNotNull(response.Result);

            Console.WriteLine($"Response: { response.Result.SelectSingleNode("ftpdata")?.InnerText}");
        }
    }
}
