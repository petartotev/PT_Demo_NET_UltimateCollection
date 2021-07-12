using System;
using System.Threading.Tasks;

// Article 5: Advanced Tips for Using Task.Run With Async/Await

// As you probably recall, await captures information about the current thread when used with Task.Run.
// It does that so execution can continue on the original thread when it is done processing on the other thread.

// But what if the rest of the code in the calling method doesn't need to be run on the original thread?
// In that case, it turns out you can give your code a bit of a performance boost by telling await that
// you don't want to continue in the original context. This is done by using a Task method called ConfigureAwait.

namespace Personal.Async.Pluralsight.Article._5.AsyncTaskRun
{
    public class Program
    {
        public static async Task Main()
        {
            await DoAsyncThing();

            // .ConfigureAwait(bool continueOnCapturedContext) configures an awaiter used to await this task.
            await DoAnotherAsyncThing().ConfigureAwait(false);

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main Thread");
            }
        }

        public static async Task DoAsyncThing()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine(i);
                }
            });
        }

        public static async Task DoAnotherAsyncThing()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            Console.WriteLine("Escape");
                            break;
                        default:
                            Console.WriteLine("Default");
                            break;
                    }
                }
            });
        }
    }
}
