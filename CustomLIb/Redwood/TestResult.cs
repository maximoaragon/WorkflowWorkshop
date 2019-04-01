using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLib.Redwood
{
    public class TestReport
    {
        public string ReportNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Client { get; set; }
        public DateTime DOB { get; set; }

        public DateTime Received { get; set; }
        public DateTime Reported { get; set; }
        public string SpecimenType { get; set; }

        public IEnumerable<TestResult> Tests{ get; set; }
    }

    public class TestResult
    {
        public string Drug { get; set; }
        public bool Detected { get; set; }
        public string Method { get; set; }
    }
}
