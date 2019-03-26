using Exchange.Contracts;
using Exchange.ServerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Workflow.Test
{
    [TestClass]
    public class WorkflowTests : TestBase
    {
        private string _workflowRootDir = @"C:\Dev\repos\WorkflowWorkshop\WorkflowLib";

        [TestMethod]
        public void SimpleDESExchange()
        {
            //Mock exchange
            ExchangeRequest request = new ExchangeRequest()
            {
                ExchangeID = 9999,
                RequestID = Guid.NewGuid().ToString(),
                ExchangeName = "UCR CaseInitiation",
                ExchangeParameters = new Dictionary<string, string>() {
                    { "MYMANE", "Max" }
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
        }
    }
}
