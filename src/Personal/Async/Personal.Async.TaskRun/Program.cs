using System;
using System.Threading;
using System.Threading.Tasks;

// Multithreaded programming = 8 threads, 8 tasks.
// Asynchronous programming = 1 thread, many tasks.
// For example: 1 waiter, 8 chefs (processor cores), 100 tables (processes). The waiter is a Task Scheduler.
namespace Personal.General.TaskRun
{
    public class Program
    {
        // Task Parallel Library (TPL)
        public static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                // Thread = Fundamental unit of code execution

                // Task = Piece of work that has to be done. #NikiTM
                // 100 tasks, but only 8 threads creates "backstrage".
                // Task Scheduler
                Task.Run(() => PlayMusic());

                Task myTask = new Task(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine("...");
                        Thread.Sleep(100);
                    }
                });
                myTask.Start();

                Task.Run(() =>
                {
                    for (int i = 65; i <= 90; i++)
                    {
                        Console.WriteLine((char)i);
                        Thread.Sleep(250);
                    }
                })
                .ContinueWith((previousTask) => // Here starts the second task >
                {
                    for (int j = 122; j >= 97; j--)
                    {
                        Console.WriteLine((char)j);
                        Thread.Sleep(250);
                    }
                });

                Task<string>.Run(() => { return "string"; });

                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        private static void PlayMusic()
        {
            for (int i = 1; i <= 2; i++)
            {
                Console.Beep(300, 500);
                Console.Beep(400, 500);
                Console.Beep(300, 500);
                Console.Beep(400, 500);
                Console.Beep(500, 750);
                Console.Beep(500, 750);
                Thread.Sleep(100);
            }

            Console.Beep(600, 500);
            Console.Beep(500, 500);
            Console.Beep(600, 500);
            Console.Beep(500, 500);
            Console.Beep(400, 750);
            Console.Beep(400, 750);
            Thread.Sleep(200);

            Console.Beep(500, 500);
            Console.Beep(400, 500);
            Console.Beep(500, 500);
            Console.Beep(400, 500);
            Console.Beep(300, 750);
            Console.Beep(300, 900);
            Thread.Sleep(200);
        }
    }
}
