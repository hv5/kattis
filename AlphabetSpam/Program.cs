using System;
using System.Text;

namespace AlphabetSpam
{
    class Program
    {
        private string _str;

        void Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            while ((_str = Console.ReadLine()) != null)
                Process();   

            watch.Stop();
            //Console.Error.WriteLine("Completed in {0} ms", watch.ElapsedMilliseconds);  
        }

        void Process()
        {
            //var parts = str.Split(new char[] {' '}, StringSplitOptions.None);

            int countAll = _str.Length;
            int countUpperCase = 0; 
            int countLowerCase = 0; 
            int countUnderScore = 0; 
            int countOtherSymbol = 0;

            byte[] bytes = Encoding.ASCII.GetBytes(_str);
            foreach (byte b in bytes)
            {
                if (b == 95) // underscore
                    countUnderScore++;
                else if (b >= 97 && b <= 122) // lowercase
                    countLowerCase++;
                else if (b >= 65 && b <= 90) // uppercase
                    countUpperCase++;
                else 
                    countOtherSymbol++; // other
            }
            
            if (countAll > 0) 
            {
                Console.WriteLine((double)countUnderScore/countAll);
                Console.WriteLine((double)countLowerCase/countAll);
                Console.WriteLine((double)countUpperCase/countAll);
                Console.WriteLine((double)countOtherSymbol/countAll);            
            }
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
 