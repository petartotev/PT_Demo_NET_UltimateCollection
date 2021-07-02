using System;
using System.Threading;

namespace Personal.General.ThreadsShareResLock
{
    public class Program
    {
        public static void Main()
        {
            // Money is shared between 2 threads => WARNING: RACE CONDITION!
            decimal money = 0;
            object padlock = new object();

            var thread1 = new Thread(() =>
            {
                for (int i = 0; i < 100_000; i++)
                {
                    // Thread safety.
                    lock (padlock)
                    {
                        money++;
                    }
                }
            });
            thread1.Start();

            var thread2 = new Thread(() =>
            {
                for (int j = 0; j < 100_000; j++)
                {
                    // The less code we lock - the better.
                    lock (padlock)
                    {
                        money++;
                    }
                }
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine(money);
            // Exactly 200_000.
        }

        public static void MainUsing1ResourceFor2ThreadsWithoutLockingGivingBadResults()
        {
            decimal money = 0;

            var thread1 = new Thread(() =>
            {
                for (int i = 0; i < 100_000; i++)
                {
                    money++;
                }
            });
            thread1.Start();

            var thread2 = new Thread(() =>
            {
                for (int j = 0; j < 100_000; j++)
                {
                    money++;
                }
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine(money);
            // Something in between 100_000 and 200_000.
        }
    }
}
