using System;

namespace Rimski
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
        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
