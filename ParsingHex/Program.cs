using System;
using System.Text.RegularExpressions;

namespace ParsingHex
{
   class Program
    {  
        private string _str;
        private Regex _regex;

        public Program()
        {
            _regex = new Regex(@"(0[xX][0-9a-fA-F]+)"); // hexadecimal 
        }

        void Run()
        {
            while ((_str = Console.ReadLine()) != null) 
                Process();     
        }

        void Process()
        {
            //Console.Error.WriteLine(_str);

            foreach (Match match in _regex.Matches(_str))
            {
                string hexValue = match.Value;                
                long decValue = Convert.ToUInt32(hexValue, 16);
                Console.WriteLine("{0} {1}", hexValue, decValue);
            }          
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
