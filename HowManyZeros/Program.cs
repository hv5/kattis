using System;
using System.Text;

namespace HowManyZeros
{
    class Program
    {
        private string _str;

        void Run()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            while ((_str = Console.ReadLine()) != null)
            {
                if (!Process())
                    break;
            }

            watch.Stop();
            Console.Error.WriteLine("[Completed in {0} ms]", watch.ElapsedMilliseconds);  
        }

        bool Process()
        {
            var parts = _str.Split(new char[] {' '}, StringSplitOptions.None);
            if (parts.Length < 2)
                return false;

            long m = Int64.Parse(parts[0]);
            long n = Int64.Parse(parts[1]);

            if (m < 0)
                return false;

            long lower = CountZerosTo(m);
            long upper = CountZerosTo(n);
            long zeros = CountZeros(m);

            Console.WriteLine(upper - lower + zeros);

            return true;
        }

        static long CountZeros(long n)
        {
            long nzeros = 0;

            if (n == 0)
                return 1;

            while (n > 0) 
            {
                if (n % 10 == 0)
                    nzeros++;
                n /= 10;
            }

            return nzeros;
        }

        public static long CountZerosTo(long n) {

            long zeros = 0;
            long digit, left, right;

            for (int i = 1; ; i *= 10) {

                digit = n / i;
                right = n % i;
                left = digit / 10;
                digit = digit % 10;

                if (left == 0)
                    return zeros;

                if (digit == 0) {
                    zeros += (left - 1) * i + right + 1;
                } else {
                    zeros += left * i;
                }
            }
        }
        
        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }
    }
}
 