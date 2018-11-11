using System;
using System.Text;

namespace Yoda
{
   class Program
    {
        private string _str1;
        private string _str2;

        void Start()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Run();
            watch.Stop();
            //Console.Error.WriteLine("Completed in {0} ms", watch.ElapsedMilliseconds);
        }

        void Run()
        {
            _str1 = Console.ReadLine();
            _str2 = Console.ReadLine();

            Process();    
        }

        void Process()
        {
            PrepareInputValues();

            //Console.Error.WriteLine(_str1);
            //Console.Error.WriteLine(_str2);

            StringBuilder builder1 = new StringBuilder(16);
            StringBuilder builder2 = new StringBuilder(16);

            int len = _str1.Length; // at this point both strings have same length

            for (int i = 0; i < len; i++)
            {
                char c1 = _str1[i];
                char c2 = _str2[i];

                int n1 = (int)char.GetNumericValue(c1);
                int n2 = (int)char.GetNumericValue(c2);

                if (n1 > n2)
                    builder1.Append(c1);
                else if (n1 < n2)
                    builder2.Append(c2);
                else {
                    builder1.Append(c1);
                    builder2.Append(c2);
                }
            }

            string s1 = "YODA";
            string s2 = "YODA";

            if (builder1.Length > 0)
                s1 = Convert.ToString(Int32.Parse(builder1.ToString()));
            if (builder2.Length > 0)
                s2 = Convert.ToString(Int32.Parse(builder2.ToString()));
                
            Console.WriteLine(s1);
            Console.WriteLine(s2);

        }

        void PrepareInputValues()
        {
            int diffLength = Math.Abs(_str1.Length - _str2.Length);
            if (diffLength > 0)
            {
                string zeroPrefix = new String('0', diffLength);
                if (_str1.Length < _str2.Length)
                    _str1 = zeroPrefix + _str1;
                else
                    _str2 = zeroPrefix + _str2;
            }
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Start();
        }
    }
}
