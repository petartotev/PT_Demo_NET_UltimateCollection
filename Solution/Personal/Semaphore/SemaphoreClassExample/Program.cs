using System;
using System.Threading;

namespace SemaphoreClassExample
{
    public class Program
    {
        private static int _padding;
        private static Semaphore _pool;

        public static void Main()
        {
            // new Semaphore (initial count, maximum count)
            _pool = new Semaphore(0, 3);

            for (int i = 1; i <= 5; i++)
            {
                // Initializes a new instance of the Thread class, specifying a delegate that allows an object to be passed to the thread when the thread is started.
                // ParametrizedThreadStart is a delegate that allows an object to be passed to the thread once the thread starts.
                Thread thr = new Thread(new ParameterizedThreadStart(Worker));

                thr.Start(i);
            }

            Thread.Sleep(500);

            Console.WriteLine("Main thread releases the entire semaphore count.");
            // Exits the semaphore a specified number of times and returns the previous count.
            _pool.Release(3);

            Console.WriteLine("Main thread exits.");
        }

        private static void Worker(object num)
        {
            Console.WriteLine("Thread {0} begins and waits for the semaphore.", num);
            _pool.WaitOne();
            Console.WriteLine("Thread {0} enters the semaphore.", num);

            // System.Threading.Interlocked provides atomic operations for variables that are shared by multiple threads.
            // Add(ref int location1, int value) adds two 32 - bit integers and replaces the first integer with the sum, as an atomic operation.
            int padding = Interlocked.Add(ref _padding, 100);
            Thread.Sleep(1000 + padding);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            // Exits the semaphore and returns the previous count.
            Console.WriteLine("Thread {0} previous semaphore count: {1}", num, _pool.Release());
        }
    }
}
