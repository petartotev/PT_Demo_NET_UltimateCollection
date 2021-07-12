using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

// Article 1: Async Programming With the .NET's Task Parallel Library (TPL)

// TPL = a set of software APIs in the System.Threading.Tasks namespace of .NET.
// TPL comes with version 4.0 of the .NET Framework.

// Asynchronous programming is a bit more general in that it has to do with latency.
// (something on which your application has to wait, for one reason or another)
// ASYNCHRONOUS <=> WAITING

// Multithreaded programming is a way to achieve parallelization.
// (one or more things that your application has to do at the same time)
// MULTITHREADED <=> PARALLELISM

// So, the idea of WAITING is the more general characteristic that is referenced by the term asynchronous, regardless of thread count.

// TASK is a beautiful abstraction, that can be used for anything that the application needs to wait for.
// TASK represents an asynchronous operation (that usually executes asynchronously).

// For each Task we are adding what's called a continuation using a function called ContinueWith.
// The continuation is a new task and is started automatically by the TPL when the antecedent (i.e. previous) task completes.

// If we maintain a list of those tasks, when we get to the last image we can use Task.WhenAll
// to aggregate all of them into a single task, to which we can again add a continuation via ContinueWith.

namespace Personal.Async.Pluralsight.Article._1.TPL
{
    public class Program
    {
        public static void Main()
        {
            //ExecuteExample1();
            //ExecuteExample2();
            ExecuteExample3();
            //ExecuteExample4();
            //ExecuteExample5();
        }

        private static void ExecuteExample1()
        {
            Task.Run(() =>
            {
                using (var myWriter = new StreamWriter(@"C:\Users\petar.totev\Desktop\task0.txt"))
                {
                    myWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss:fffffff"));
                    for (int i = 1; i <= 20; i++)
                    {
                        myWriter.WriteLine(i.ToString());
                        Thread.Sleep(50);
                    }
                    myWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss:fffffff"));
                }
            });

            // Without the Sleep of the current Thread - the tasks above don't manage to execute before the end of the execution of the program.
            Thread.Sleep(2000);
        }

        private static void ExecuteExample2()
        {
            // Task 1
            Task myTask1 = Task.Run(() =>
            {
                using (var myWriter = new StreamWriter(@"C:\Users\petar.totev\Desktop\task1.txt"))
                {
                    myWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss:fffffff"));
                    for (int i = 1; i <= 123456; i++)
                    {
                        myWriter.WriteLine(i.ToString());
                    }
                    myWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss:fffffff"));
                }
            });

            // Task 2
            Task myTask2 = Task.Run(() =>
            {
                int num = 0;
                using var myWriter = new StreamWriter(@"C:\Users\petar.totev\Desktop\task2.txt");
                myWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss:fffffff"));
                for (int i = 0; i < 10000; i++)
                {
                    num += i;
                    myWriter.WriteLine(num);
                }
                myWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss:fffffff"));
            });

            // Task 3
            Task myTask3 = Task.Run(() =>
            {
                using var myWriter = new StreamWriter(@"C:\Users\petar.totev\Desktop\task3.txt");
                for (int i = 0; i < 10000; i++)
                {
                    myWriter.Write("|");
                }
                myWriter.WriteLine("Both myTask1 and myTask2 are completed so you see this message");
                myWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss:fffffff"));
            });

            // List of Tasks = Task 1, Task 2
            Task[] tasks = new Task[] { myTask1, myTask2 };

            // When the List of Tasks (Task1, Task2) is executed then continue with Task 3.
            var taskTotal = Task.WhenAll(tasks).ContinueWith(x => myTask3);

            // Without the Sleep of the current Thread - the tasks above don't manage to execute before the end of the execution of the program.
            Thread.Sleep(3000);
        }

        private static void ExecuteExample3()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            // Play song on another parallel thread.
            // Pass the token in order to cancel the task later from this thread.
            PlayMusic(token);

            // Execute an infinite loop on the current thread.
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Spacebar:
                        source.Cancel();
                        break;
                    default:
                        Console.WriteLine(key.ToString());
                        break;
                }
            }
        }

        private static Task PlayMusic(CancellationToken token)
        {
            return Task.Run(() =>
                {
                    Sample mySample = new Sample();

                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }

                        mySample.Play(mySample.Mary);

                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                    }
                }, token);
        }

        private static void ExecuteExample4()
        {
            GetInput().ContinueWith(task1 =>
            {
                Console.WriteLine($"First we got the input in a different thread then we ContinueWith printing it here: {task1.Result}.");
            });

            Console.WriteLine(TaskString().Result);

            Thread.Sleep(5000);
        }

        private static Task<string> GetInput()
        {
            return Task.Run(() => Console.ReadLine());
        }

        private static Task<string> TaskString()
        {
            return Task.Run(() => ReturnString());
        }

        private static string ReturnString()
        {
            return Guid.NewGuid().ToString("N");
        }

        private static void ExecuteExample5()
        {
            Task task1 = Task.Run(() => throw new Exception("An exception is thrown!!!"));

            Console.WriteLine(@"task1.Id: {0}", task1.Id);
            Console.WriteLine(@"task1.Status: {0}", task1.Status);
            Console.WriteLine(@"task1.IsFaulted: {0}", task1.IsFaulted);
            Console.WriteLine(@"task1.IsCanceled: {0}", task1.IsCanceled);
            Console.WriteLine(@"task1.IsCompleted: {0}", task1.IsCompleted);
            Console.WriteLine(@"task1.IsCompletedSuccessfully: {0}", task1.IsCompletedSuccessfully);
            Console.WriteLine(@"task1.AsyncState: {0}", task1.AsyncState);
            Console.WriteLine(@"task1.CreationOptions.ToString(): {0}", task1.CreationOptions.ToString());

            Console.WriteLine(new string('_', 100));

            Console.WriteLine(@"task1.Exception.Data.Keys.IsSynchronized: {0}", task1.Exception.Data.Keys.IsSynchronized);
            Console.WriteLine(@"task1.Exception.Flatten().ToString(): {0}", task1.Exception.Flatten().ToString());
            Console.WriteLine(@"task1.Exception.InnerExceptions.Count: {0}", task1.Exception.InnerExceptions.Count);
            Console.WriteLine(@"task1.Exception.Message: {0}", task1.Exception.Message);
        }
    }
}
