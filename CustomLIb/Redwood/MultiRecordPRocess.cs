using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace CustomLib.Redwood
{
    public class MultiRecordProcess
    {

        [DelimitedRecord("|")]
        //Laboratory Report comments – optional, repeating
        public sealed class NTE
        {

            private String mNTE00;
            public String NTE00
            {
                get { return mNTE00; }
                set { mNTE00 = value; }
            }

            private String mNTE01;

            public String NTE01
            {
                get { return mNTE01; }
                set { mNTE01 = value; }
            }


            private String mNTE02;

            public String NTE02
            {
                get { return mNTE02; }
                set { mNTE02 = value; }
            }


            private String mNTE03;

            public String NTE03
            {
                get { return mNTE03; }
                set { mNTE03 = value; }
            }

            public override string ToString()
            {
                return "NTE Record: " + NTE00 + "  " + NTE03;
            }

        }

        [DelimitedRecord("|")]
        //Message Header - required, non-repeating
        public sealed class MSH
        {

            private String mMSH00;

            public String MSH00
            {
                get { return mMSH00; }
                set { mMSH00 = value; }
            }


            private String mMSH01;

            public String MSH01
            {
                get { return mMSH01; }
                set { mMSH01 = value; }
            }


            private String mMSH02;

            public String MSH02
            {
                get { return mMSH02; }
                set { mMSH02 = value; }
            }


            private String mMSH03;

            public String MSH03
            {
                get { return mMSH03; }
                set { mMSH03 = value; }
            }


            private String mMSH04;

            public String MSH04
            {
                get { return mMSH04; }
                set { mMSH04 = value; }
            }


            private String mMSH05;

            public String MSH05
            {
                get { return mMSH05; }
                set { mMSH05 = value; }
            }


            private String mMSH06;

            public String MSH06
            {
                get { return mMSH06; }
                set { mMSH06 = value; }
            }


            private String mMSH07;

            public String MSH07
            {
                get { return mMSH07; }
                set { mMSH07 = value; }
            }


            private String mMSH08;

            public String MSH08
            {
                get { return mMSH08; }
                set { mMSH08 = value; }
            }


            private String mMSH09;

            public String MSH09
            {
                get { return mMSH09; }
                set { mMSH09 = value; }
            }


            private String mMSH10;

            public String MSH10
            {
                get { return mMSH10; }
                set { mMSH10 = value; }
            }


            private String mMSH11;

            public String MSH11
            {
                get { return mMSH11; }
                set { mMSH11 = value; }
            }


            private String mMSH12;

            public String MSH12
            {
                get { return mMSH12; }
                set { mMSH12 = value; }
            }
            public override string ToString()
            {
                return "MSH Record: " + MSH00 + "  " + MSH09;
            }

        }

        [DelimitedRecord("|")]
        //Observation Request - required, repeating as block 1
        public sealed class OBR
        {

            private String mOBR00;

            public String OBR00
            {
                get { return mOBR00; }
                set { mOBR00 = value; }
            }


            private String mOBR01;

            public String OBR01
            {
                get { return mOBR01; }
                set { mOBR01 = value; }
            }


            private String mOBR02;

            public String OBR02
            {
                get { return mOBR02; }
                set { mOBR02 = value; }
            }


            private String mOBR03;

            public String OBR03
            {
                get { return mOBR03; }
                set { mOBR03 = value; }
            }


            private String mOBR04;

            public String OBR04
            {
                get { return mOBR04; }
                set { mOBR04 = value; }
            }


            private String mOBR05;

            public String OBR05
            {
                get { return mOBR05; }
                set { mOBR05 = value; }
            }


            private String mOBR06;

            public String OBR06
            {
                get { return mOBR06; }
                set { mOBR06 = value; }
            }


            private String mOBR07;

            public String OBR07
            {
                get { return mOBR07; }
                set { mOBR07 = value; }
            }


            private String mOBR08;

            public String OBR08
            {
                get { return mOBR08; }
                set { mOBR08 = value; }
            }


            private String mOBR09;

            public String OBR09
            {
                get { return mOBR09; }
                set { mOBR09 = value; }
            }


            private String mOBR10;

            public String OBR10
            {
                get { return mOBR10; }
                set { mOBR10 = value; }
            }


            private String mOBR11;

            public String OBR11
            {
                get { return mOBR11; }
                set { mOBR11 = value; }
            }


            private String mOBR12;

            public String OBR12
            {
                get { return mOBR12; }
                set { mOBR12 = value; }
            }

            private String mOBR13;

            public String OBR13
            {
                get { return mOBR13; }
                set { mOBR13 = value; }
            }

            private String mOBR14;

            public String OBR14
            {
                get { return mOBR14; }
                set { mOBR14 = value; }
            }

            private String mOBR15;

            public String OBR15
            {
                get { return mOBR15; }
                set { mOBR15 = value; }
            }

            private String mOBR16;

            public String OBR16
            {
                get { return mOBR16; }
                set { mOBR16 = value; }
            }

            private String mOBR17;

            public String OBR17
            {
                get { return mOBR17; }
                set { mOBR17 = value; }
            }
            private String mOBR18;

            public String OBR18
            {
                get { return mOBR18; }
                set { mOBR18 = value; }
            }
            private String mOBR19;

            public String OBR19
            {
                get { return mOBR19; }
                set { mOBR15 = value; }
            }
            private String mOBR20;

            public String OBR20
            {
                get { return mOBR20; }
                set { mOBR20 = value; }
            }

            private String mOBR21;

            public String OBR21
            {
                get { return mOBR21; }
                set { mOBR21 = value; }
            }

            private String mOBR22;

            public String OBR22
            {
                get { return mOBR22; }
                set { mOBR22 = value; }
            }

            private String mOBR23;

            public String OBR23
            {
                get { return mOBR23; }
                set { mOBR23 = value; }
            }

            private String mOBR24;

            public String OBR24
            {
                get { return mOBR24; }
                set { mOBR24 = value; }
            }

            private String mOBR25;

            public String OBR25
            {
                get { return mOBR25; }
                set { mOBR25 = value; }
            }

            public override string ToString()
            {
                return "OBR Record: " + OBR00 + "  " + OBR25;
            }


        }

        [DelimitedRecord("|")]
        //Observation Result - required, repeating as block 2
        public sealed class OBX
        {
            private String mOBX00;
            public String OBX00
            {
                get { return mOBX00; }
                set { mOBX00 = value; }
            }
            private String mOBX01;
            public String OBX01
            {
                get { return mOBX01; }
                set { mOBX01 = value; }
            }
            private String mOBX02;
            public String OBX02
            {
                get { return mOBX02; }
                set { mOBX02 = value; }
            }
            private String mOBX03;
            public String OBX03
            {
                get { return mOBX03; }
                set { mOBX03 = value; }
            }
            private String mOBX04;
            public String OBX04
            {
                get { return mOBX04; }
                set { mOBX04 = value; }
            }
            private String mOBX05;
            public String OBX05
            {
                get { return mOBX05; }
                set { mOBX05 = value; }
            }
            private String mOBX06;
            public String OBX06
            {
                get { return mOBX06; }
                set { mOBX06 = value; }
            }
            private String mOBX07;
            public String OBX07
            {
                get { return mOBX07; }
                set { mOBX07 = value; }
            }
            private String mOBX08;
            public String OBX08
            {
                get { return mOBX08; }
                set { mOBX08 = value; }
            }
            private String mOBX09;
            public String OBX09
            {
                get { return mOBX09; }
                set { mOBX09 = value; }
            }
            private String mOBX10;
            public String OBX10
            {
                get { return mOBX10; }
                set { mOBX10 = value; }
            }
            private String mOBX11;
            public String OBX11
            {
                get { return mOBX11; }
                set { mOBX11 = value; }
            }
            private String mOBX12;
            public String OBX12
            {
                get { return mOBX12; }
                set { mOBX12 = value; }
            }
            private String mOBX13;
            public String OBX13
            {
                get { return mOBX13; }
                set { mOBX13 = value; }
            }
            private String mOBX14;
            public String OBX14
            {
                get { return mOBX14; }
                set { mOBX14 = value; }
            }
            public override string ToString()
            {
                return "OBX Record: " + OBX00 + "  " + OBX01 + "  " + OBX03 + "  " + OBX05;
            }
        }
        [DelimitedRecord("|")]
        //Commom Order
        public sealed class ORC
        {

            private String mORC00;

            public String ORC00
            {
                get { return mORC00; }
                set { mORC00 = value; }
            }


            private String mORC01;

            public String ORC01
            {
                get { return mORC01; }
                set { mORC01 = value; }
            }


            private String mORC02;

            public String ORC02
            {
                get { return mORC02; }
                set { mORC02 = value; }
            }


            private String mORC03;

            public String ORC03
            {
                get { return mORC03; }
                set { mORC03 = value; }
            }

            public override string ToString()
            {
                return "ORC Record: " + ORC00 + "  " + ORC01;
            }

        }

        [DelimitedRecord("|")]
        //Patient Identification - required, non-repeating
        public sealed class PID
        {

            private String mPID00;

            public String PID00
            {
                get { return mPID00; }
                set { mPID00 = value; }
            }


            private String mPID01;

            public String PID01
            {
                get { return mPID01; }
                set { mPID01 = value; }
            }


            private String mPID02;

            public String PID02
            {
                get { return mPID02; }
                set { mPID02 = value; }
            }


            private String mPID03;

            public String PID03
            {
                get { return mPID03; }
                set { mPID03 = value; }
            }


            private String mPID04;

            public String PID04
            {
                get { return mPID04; }
                set { mPID04 = value; }
            }


            private String mPID05;

            public String PID05
            {
                get { return mPID05; }
                set { mPID05 = value; }
            }


            private String mPID06;

            public String PID06
            {
                get { return mPID06; }
                set { mPID06 = value; }
            }


            private String mPID07;

            public String PID07
            {
                get { return mPID07; }
                set { mPID07 = value; }
            }


            private String mPID08;

            public String PID08
            {
                get { return mPID08; }
                set { mPID08 = value; }
            }


            private String mPID09;

            public String PID09
            {
                get { return mPID09; }
                set { mPID09 = value; }
            }


            private String mPID10;

            public String PID10
            {
                get { return mPID10; }
                set { mPID10 = value; }
            }


            private String mPID11;

            public String PID11
            {
                get { return mPID11; }
                set { mPID11 = value; }
            }


            private String mPID12;

            public String PID12
            {
                get { return mPID12; }
                set { mPID12 = value; }
            }

            private String mPID13;

            public String PID13
            {
                get { return mPID13; }
                set { mPID13 = value; }
            }

            private String mPID14;

            public String PID14
            {
                get { return mPID14; }
                set { mPID14 = value; }
            }

            private String mPID15;

            public String PID15
            {
                get { return mPID15; }
                set { mPID15 = value; }
            }

            private String mPID16;

            public String PID16
            {
                get { return mPID16; }
                set { mPID16 = value; }
            }

            public override string ToString()
            {
                return "PID Record: " + PID00 + "  " + PID03 + "  " + PID05;
            }



        }

        public IEnumerable<TestReport> Run(string fileName)
        {

            var engine = new MultiRecordEngine(typeof(NTE),
                typeof(MSH),
                typeof(OBR),
                typeof(OBX),
                typeof(ORC),
                typeof(PID));

            //engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            //var res = engine.ReadFile(fileName);

            //foreach (var rec in res)
            //    Console.WriteLine(rec.ToString());

            //mocked report
            return new List<TestReport>()
            {
                new TestReport
                {
                    ReportNumber = "JP-321456",
                    Client = "Jessie Pinkman",
                    Received = DateTime.Now.Subtract(TimeSpan.FromDays(2)),
                    Reported = DateTime.Now,
                    Tests = new List<TestResult>()
                    {
                         new TestResult() { Drug ="Alcohol", Detected = true },
                         new TestResult() { Drug ="Cocaine", Detected = false },
                         new TestResult() { Drug ="THC (Marijuana)", Detected = true },
                    }
                }
            };
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            string firstThreeChar = new string(recordLine.Take(3).ToArray());

            if (recordLine.Length == 0)
                return null;

            switch (firstThreeChar)
            {
                case "NTE":
                    return typeof(NTE);
                case "MSH":
                    return typeof(MSH);
                case "OBR":
                    return typeof(OBR);
                case "OBX":
                    return typeof(OBX);
                case "ORC":
                    return typeof(ORC);
                default:
                    return typeof(PID);

            }

        }
    }
}
