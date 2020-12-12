using System;
using System.Threading;
using System.Threading.Tasks;

namespace Personal.General.TaskRun
{
    public class Program
    {
        // Task Parallel Library (TPL)
        public static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                // 100 tasks, but only 8 threads creates "backstrage".
                Task.Run(() =>
                {
                    Thread.Sleep(10000);
                });


                Task myTask = new Task(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine("...");
                        Thread.Sleep(100);
                    }
                });
                myTask.Start();

                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        public static void Main2()
        {
            // Task Scheduler
            // Task = Piece of work that has to be done. NikiTM
            Task.Run(() =>
            {
                for (int i = 65; i <= 90; i++)
                {
                    Console.WriteLine((char)i);
                    Thread.Sleep(250);
                }
            })
            .ContinueWith((previousTask) =>
            {
                for (int j = 122; j >= 97; j--)
                {
                    Console.WriteLine((char)j);
                    Thread.Sleep(250);
                }
            });

            while (true)
            {
                Console.ReadLine();
            }            
        }        
    }
}

// Asynchronous - 1 thread, many tasks
// 1 waiter, 8 chefs (processor cores), 100 tables (processes).
// The waiter is a Task Scheduler.

// Multithreading - 8 threads, 8 tasks.