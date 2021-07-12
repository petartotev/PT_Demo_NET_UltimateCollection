using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Personal.Async.Pluralsight.Article._3.ControlFlow
{
    public class Program
    {
        public static async Task Main()
        {
            // The current thread does absolutely nothing until the sleep operation has completed.
            // Another way to describe it is that the thread waits synchronously.
            Thread.Sleep(1000);

            Task<string> myTask = new HttpClient().GetStringAsync("http://petartotev.net");

            // We're calling GetAwaiter().GetResult() on the task, which is a blocking call.
            // Again, this is synchronous; no execution will take place on the current thread until GetResult
            // returns with the data returned by the operation (the requested string data in this example).
            string stringyBoo = myTask.GetAwaiter().GetResult();
            Console.WriteLine(stringyBoo.Substring(0, 101));

            // Similarly, a task's Result property also blocks synchronously until data is returned.
            string stringyFoo = myTask.Result;
            Console.WriteLine(stringyFoo.Substring(0, 101));

            // Last but not least, there's also a Wait method that is blocking, e.g.:
            myTask.Wait();
            Console.WriteLine(myTask.IsCompletedSuccessfully);

            // The await keyword, by contrast, is non - blocking, which means the current thread is free to do other things during the wait.
            await DoAsyncThing();
            Console.WriteLine("This will be printed when DoAsyncThing() is done.\n\r" +
                              "Nevertheless, the current thread will be free to do other things in the meantime.");

            Task task1 = Task.Run(() => Console.WriteLine());
            Task task2 = Task.Run(() => Console.WriteLine());

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            task1.ContinueWith(task => task2, TaskContinuationOptions.OnlyOnFaulted);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        public static async Task DoAsyncThing()
        {
            await Task.Run(() =>
            {
                int num = 0;
                for (int i = 0; i < int.MaxValue; i++)
                {
                    num = i % 2 == 0 ? num++ : num--;
                }
            });
        }
    }
}
