using System;

namespace ParsingHex
{
   class Program
    {  
        void Run()
        {
            string line;
            while ((line = Console.ReadLine()) != null)
                Process(line);     
        }

        void Process(string str)
        {
            Console.Error.WriteLine(str);


        }

        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
