using System;
using System.Threading;

// Process = an isolated memory structure which supports an application in OS hardware and software. A Windows Process contains 1 or more Threads.
// Thread = a stream of sequential machine-code instructions that the processor executes.
// Handle = a logical association with a shared resource like a file, Window, memory location, etc. Something like a 'number' for the resource.
namespace Personal.General.ThreadNew
{
    public class Program
    {
        // 1 Process contains at least 1 Main Thread.
        // From the Main-Main() you cannot try-catch an exception coming from another thread...
        public static void Main()
        {
            // Threads is a fundamental unit of code execution.
            // Threads have instructions, their own Call Stack / Stack Trace, 'Main Method'...
            // Threads are very 'expensive'!
            // Thread is a sub-program of our main program, when our program does more than one thing.
            Thread myThread = new Thread(MainMethodMyThread);
            myThread.Start();

            new Thread(() => Console.WriteLine("This is Console.Written by myThread2!")).Start();

            while (true)
            {
                Console.WriteLine(Console.ReadLine().ToUpperInvariant());
            }
        }

        private static void MainMethodMyThread()
        {
            int num = CalculateSomething();
            Console.WriteLine($"CalculateSomething() result: " + num);
        }

        private static int CalculateSomething()
        {
            int num = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                num = i;
            }
            return num;
        }
    }
}