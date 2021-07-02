using System;

// Task Manager > Performance
// Sockets: 1
// Cores: 6
// Logical processors: 12
namespace Personal.Async.Synchronous
{
    public class Program
    {
        // Once the synchronous program is run a 'Console Window Host' process is started.
        // It consumes around 12.5% CPU power.
        public static void Main()
        {
            int num = 0;

            while (true)
            {
                num++;
                Console.WriteLine(num);

                num--;
                Console.WriteLine(num);
            }
        }
    }
}
