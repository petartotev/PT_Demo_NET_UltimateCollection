namespace Personal.General.SemaphoreSlimShady;

public class Program
{
    private static readonly SemaphoreSlim _semaphoreSlimShady = new(3, 3);

    public static async Task Main()
    {
        Console.WriteLine("Starting tasks...");

        var tasks = new Task[10];

        for (int i = 0; i < tasks.Length; i++)
        {
            int taskNumber = i; // Avoid closure issue
            tasks[i] = Task.Run(() => AccessResourceAsync(taskNumber));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("All tasks completed.");

        /*
        Starting tasks...
        Task 1 waiting to enter...
        Task 0 waiting to enter...
        Task 2 waiting to enter...
        Task 3 waiting to enter...

        Task 0 entered.
        Task 1 entered.
        Task 2 entered.

        Task 4 waiting to enter...
        Task 5 waiting to enter...
        Task 6 waiting to enter...
        Task 7 waiting to enter...
        Task 8 waiting to enter...
        Task 9 waiting to enter...

        Task 0 exiting.
        Task 1 exiting.
        Task 2 exiting.

        Task 3 entered.
        Task 4 entered.
        Task 5 entered.
        Task 4 exiting.
        Task 3 exiting.
        Task 5 exiting.
        Task 8 entered.
        Task 7 entered.
        Task 6 entered.
        Task 6 exiting.
        Task 7 exiting.
        Task 8 exiting.
        Task 9 entered.
        Task 9 exiting.

        All tasks completed.
         */
    }

    private static async Task AccessResourceAsync(int taskNumber)
    {
        Console.WriteLine($"Task {taskNumber} waiting to enter...");

        await _semaphoreSlimShady.WaitAsync(); // Wait to enter the critical section

        try
        {
            Console.WriteLine($"Task {taskNumber} entered.");
            await Task.Delay(1000); // Simulate resource usage
        }
        finally
        {
            Console.WriteLine($"Task {taskNumber} exiting.");
            _semaphoreSlimShady.Release(); // Release the semaphore
        }
    }
}
