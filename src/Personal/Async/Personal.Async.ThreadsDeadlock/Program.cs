using System.Threading;

namespace Personal.General.ThreadsDeadlock
{
    public class Program
    {
        // DEADLOCK!
        public static void Main()
        {
            object padlock1 = new object();
            object padlock2 = new object();

            var thread1 = new Thread(() =>
            {
                lock (padlock1)
                {
                    Thread.Sleep(1000);
                    lock (padlock2){}
                }
            });

            var thread2 = new Thread(() =>
            {
                lock (padlock2)
                {
                    Thread.Sleep(1000);
                    lock (padlock1){}
                }
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
    }
}
