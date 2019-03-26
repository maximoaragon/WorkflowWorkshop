using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Workflow.Test
{
    [TestClass]
    [DeploymentItem(@"\ClientConfiguration.dll")]
    [DeploymentItem(@"\GZipEncoder.dll")] 
    [DeploymentItem(@"\ShowCaseWorkflowActivityLib.dll")]
    [DeploymentItem(@"\ShowCaseCCB.dll")]
    [DeploymentItem(@"\ShowCasePresentation.dll")]
    [DeploymentItem(@"\Metaphone.NET.dll")]
    public class TestBase
    {
        public TestContext TestContext { get; set; }
    }
}
