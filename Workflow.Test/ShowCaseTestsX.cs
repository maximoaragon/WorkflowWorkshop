using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowCaseClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Workflow.Test
{
    [TestClass]
    public class ShowCaseTests: TestBase
    {
        [TestMethod]
        public void ExampleTest()
        {
            var authResponse = Exchange.ClientLib.AuthenticationServiceClient.AuthenticateUser("desdemo", "}k4(kxv", "ShowCasePalmBeach");

            var shellCase = ShowCaseDAL.CCaseHelper.GetShellCase(ShowCaseClassLib.CGlobal.eShowCaseDLLUsage.Other);

            int caseID = 5781496;

            shellCase.Load(caseID, false,false, false);

            var xmlDoc = new XmlDocument();
            
            //string xml = c.Partys.GetXML();
            //xmlDoc.LoadXml(xml);

            XmlElement partiesElement = xmlDoc.CreateElement("parties");
            xmlDoc.AppendChild(partiesElement);

            foreach (CParty p in shellCase.Partys)
            {
                if (p.DOB < DateTime.Now.AddYears(-18))
                {
                    var partyElement = xmlDoc.CreateElement("party");

                    //partyElement.InnerXml = $"<name>{p.FullName()}</name><language>{p.PrimaryLanguage}</language>";

                    partyElement.InnerXml = string.Format("<name>{0}</name><language>{1}</language>", p.FullName(), p.PrimaryLanguage);

                    partiesElement.AppendChild(partyElement);
                }
            }

            Console.WriteLine(xmlDoc.InnerXml);
        }
    }
}
