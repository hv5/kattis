using System;
using System.Numerics;
using System.Text;

namespace SimpleAddition
{
   class Program
    {
        private string _str1;
        private string _str2;


        void Run()
        {    
            _str1 = Console.ReadLine();
            _str2 = Console.ReadLine();

            Process();
        }

        void Process()
        {
            //Console.Error.WriteLine(_str1);
            //Console.Error.WriteLine(_str2); 

            BigInteger bigInt1 = BigInteger.Parse(_str1);
            BigInteger bigInt2 = BigInteger.Parse(_str2);

            BigInteger bigIntSum = bigInt1 + bigInt2;

            Console.WriteLine(bigIntSum.ToString());
            
        }
        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
