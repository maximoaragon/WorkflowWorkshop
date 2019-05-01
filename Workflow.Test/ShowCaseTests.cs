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
        private string _userName = "***";
        private string _pwd = "***";
        private string _friendlyDBName = "ShowCase";

        [TestMethod]
        public void ExampleTest()
        {
            var authResponse = Exchange.ClientLib.AuthenticationServiceClient.AuthenticateUser(_userName, _pwd, _friendlyDBName);

            var shellCase = ShowCaseDAL.CCaseHelper.GetShellCase(ShowCaseClassLib.CGlobal.eShowCaseDLLUsage.Other);

            int caseID = 5781496;

            #region "Spoiler"

            string caseNumber = "19-CJ-1";

            var formattedCaseNumber = shellCase.GlobalClass().ValidateCaseNumberSearchEntry_FL(caseNumber, true);
            caseID = shellCase.GlobalClass().GetCaseDAO().GetCaseIDByCaseNumber(formattedCaseNumber);
            
            #endregion

            shellCase.Load(caseID);

            var xmlDoc = new XmlDocument();

            //string xml = c.Partys.GetXML();
            //xmlDoc.LoadXml(xml);

            var partiesElement = xmlDoc.CreateElement("parties");
            xmlDoc.AppendChild(partiesElement);

            foreach (CParty p in shellCase.Partys)
            {
                if (p.DOB < DateTime.Now.AddYears(-18))
                {
                    var partyElement = xmlDoc.CreateElement("party");

                    partyElement.InnerXml = $"<name>{p.FullName()}</name><language>{p.PrimaryLanguage}</language>";

                    partiesElement.AppendChild(partyElement);
                }
            }

            Console.WriteLine(xmlDoc.InnerXml);
        }
    }
}
