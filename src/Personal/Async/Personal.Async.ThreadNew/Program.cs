using System;
using System.Threading;

namespace Personal.General.ThreadNew
{
    public class Program
    {
        public static void Main()
        {
            // Thread is a fundamental unit of code execution.
            // Threads have instructions, their own Call Stack / Stack Trace, 'Main Method'...
            // Threads are very 'expensive'!
            // Thread is a sub-program of our main-program. When our program does more than one thing.
            Thread myThread1 = new Thread(MainMyThread1);
            myThread1.Start();

            while (true)
            {
                Console.WriteLine(Console.ReadLine().ToUpperInvariant());
            }
        }

        private static void MainMyThread1()
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

// From the Main-Main() you cannot try-catch an exception coming from another thread...
// Processes => Threads => Handles (Ctrl + Alt + Del)
// Handles are references to some resource (file).
// Something like a 'number' for the resource.