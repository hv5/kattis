﻿using System;
using System.Text.RegularExpressions;

namespace Rimski
{
   class Program
    {
        private string _str;
        private int _count;

        void Run()
        {
            _str = Console.ReadLine();
            Process();    
        }

        void RunTest()
        {
            _count = 0;
          
            while ((_str = Console.ReadLine()) != null) 
                Process();    
        }

        void Process()
        {   
            _count++;

            string newRoman = _str;

            if (Regex.Match(_str, @"^LX[IV]+").Success)
                newRoman = Regex.Replace(newRoman, @"^LX([IV]+)", "XL$1");
            else if (Regex.Match(_str, @"^LX$").Success)
                newRoman = "XL";  
            else if (Regex.Match(_str, @"^LXXI$").Success)
                newRoman = "XLIX";       

            if (Regex.Match(newRoman, @"XI$").Success)
                newRoman = Regex.Replace(newRoman, @"XI$", "IX");
            else if (Regex.Match(newRoman, @"VI$").Success)
                newRoman = Regex.Replace(newRoman, @"VI$", "IV");            

            Console.WriteLine(newRoman);           
            
            /* 
            if (newRoman.Equals(_str))
                Console.Error.WriteLine("{0,-3} {1}", _count, _str);
            else
                Console.Error.WriteLine("{0,-3} {1}  =>  {2}", _count, _str, newRoman);
            */
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
