using System;
using System.Threading;

namespace Personal.General.ThreadNew
{
    public class Program
    {
        public static void Main()
        {
            Thread myThread1 = new Thread(MainMyThread1);
            myThread1.Start();

            while (true)
            {
                Console.ReadLine();
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
