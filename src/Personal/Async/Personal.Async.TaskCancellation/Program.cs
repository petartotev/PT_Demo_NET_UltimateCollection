using System;
using System.Threading;
using System.Threading.Tasks;

namespace Personal.Async.TaskCancellation
{
    public class Program
    {
        public static void Main()
        {
            //ExecuteExample1();
            ExecuteExample2();
        }

        public static void ExecuteExample1()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            // This is an infinite loop executed on another Worker Thread.
            var task = Task.Run(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine(DateTime.UtcNow);
                    Thread.Sleep(10);
                }
            }, token);

            Thread.Sleep(500);

            // Cancel the task from the Main Thread here.
            source.Cancel();

            Thread.Sleep(1000);

            // Check if task is canceled / completed successfully.
            Console.WriteLine("task.IsFaulted: {0}", task.IsFaulted);
            Console.WriteLine("task.IsCanceled: {0}", task.IsCanceled);
            Console.WriteLine("task.IsCompleted: {0}", task.IsCompleted);
            Console.WriteLine("task.IsCompletedSuccessfully: {0}", task.IsCompletedSuccessfully);
        }

        public static void ExecuteExample2()
        {
            Console.WriteLine("Press a Key to print it or Spacebar to cancel the annoying music: ");

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            // Play song on another parallel (Worker) thread.
            // Pass a token in order to cancel the task later from this thread.
            PlayMusicParallel(token);

            // Execute an infinite loop on the current (Main) thread.
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

        private static Task PlayMusicParallel(CancellationToken token)
        {
            return Task.Run(() =>
            {
                int[] tones = new int[] { 300, 400, 300, 400, 500, 500 };

                while (true)
                {
                    for (int i = 0; i < tones.Length; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Music played on a Worker Thread was stopped from the Main Thread!");
                            return;
                        }
                        Console.Beep(tones[i], tones[i]);
                    }
                }
            }, token);
        }
    }
}
