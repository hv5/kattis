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
            Console.Error.WriteLine(_str);

            int indent = 0;
            StringBuilder builder = new StringBuilder();

            foreach (char c in _str)
            {   
                if (c == '{') {
                    builder.Append("{");
                    builder.AppendLine();          
                    indent += 2;
                    builder.Append(GetIndentedString(indent, ""));
                }
                else if (c == '}') {
                    builder.AppendLine();
                    indent -= 2;
                    builder.Append(GetIndentedString(indent, "}"));
                                   
                }
                else if (c == ',') {
                    builder.Append(",");
                    builder.AppendLine();
                    builder.Append(GetIndentedString(indent, ""));
                }
                else {
                    builder.Append(c);
                }
            }

            string[] lines = builder.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string str = line.Trim();
                if (str.Length > 0)
                    Console.WriteLine(line);
            }
        }
        
        static string GetIndentedString(int shift, string str)
        {
            return new string(' ',shift) + str;
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
