using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Personal.General.AsyncAwait
{
    public class Program
    {
        public static async Task Main() // Main Thread
        {
            //InfiniteMethod();

            var stopWatch = Stopwatch.StartNew();
            int cnt = CountPrimeNumbers(1, 1_100_000);
            Console.WriteLine(cnt);
            Console.WriteLine(stopWatch.Elapsed);

            Console.WriteLine(await AsyncMethodAsync());
            Console.WriteLine("SHA LA LA");

            await DoSomethingAsync();
        }

        public static async Task<string> AsyncMethodAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://petartotev.net");
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task DoSomethingAsync()
        {
            await Task.Run(() => Console.WriteLine("Async, yes, async."));
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
