using System;
using System.Diagnostics;

namespace Personal.General.AsyncAwait
{
    public class Program
    {
        public static void Main() // Main Thread
        {
            //InfiniteMethod();

            var stopWatch = Stopwatch.StartNew();
            int cnt = CountPrimeNumbers(1, 1_500_000);
            Console.WriteLine(cnt);
            Console.WriteLine(stopWatch.Elapsed);
        }

        public static void InfiniteMethod()
        {
            int i = 0;
            while (true)
            {
                i++;
                i--;
            }
        }

        public static int CountPrimeNumbers(int from, int to)
        {
            int count = 0;
            for (int i = from; i < to; i++)
            {
                bool isPrime = true;
                for (int div = 2; div <= Math.Sqrt(i); div++)
                {
                    if (i % div == 0)
                        isPrime = false;
                }
                if (isPrime)
                    count++;
            }
            return count;
        }
    }
}
