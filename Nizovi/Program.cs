using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nizovi
{
   class Program
    {
        private string _str;
      
        void Run()
        {
            _str = Console.ReadLine();
            Process();    
        }

        void Process()
        {   
            //_str = "{a,b,{c,d},e,{}}";
            //_str = "{}";
            //Console.Error.WriteLine(_str);

            string GetIndented(int shift, string str)
            {
                return new string(' ',shift) + str;
            }

            string body = Regex.Replace(_str, @"^{(.*)}$", "$1");
            string[] parts = body.Split(',');

            int indent = 2;

            List<string> stringList = new List<string>();

            StringBuilder currentBlock = new StringBuilder();

            foreach(string part in parts)
            {
                string str = part;
                if (str.StartsWith('{')) 
                {
                    str = str.TrimStart('{');
                    currentBlock.Append(GetIndented(indent, "{")).AppendLine();
                    indent += 2;
                }
                if (str.EndsWith('}')) 
                {
                    str = str.TrimEnd('}');
                    if (str.Length > 0)
                        currentBlock.Append(GetIndented(indent, str)).AppendLine();
                    indent -= 2;
                    currentBlock.Append(GetIndented(indent, "}"));
                    stringList.Add(currentBlock.ToString());
                    currentBlock.Clear();
                    str = string.Empty;
                }

                if (currentBlock.Length > 0)
                    currentBlock.Append(GetIndented(indent, str + ',')).AppendLine();
                else if (str.Length > 0)
                    stringList.Add(GetIndented(indent, str));
            }

            Console.WriteLine('{');
            if (stringList.Count > 0)
                Console.WriteLine(string.Join(",\n", stringList.ToArray()));
            Console.WriteLine('}');
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
