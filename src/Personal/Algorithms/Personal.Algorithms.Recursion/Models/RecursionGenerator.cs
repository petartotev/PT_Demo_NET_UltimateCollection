using System.Text;

namespace Personal.Algorithms.Recursion.Models;

public class RecursionGenerator
{
    private readonly Random _random = new();

    public void InvokeStackOverflowDueToInfiniteRecursion()
    {
        // WARNING: No bottom of recursion
        InvokeStackOverflowDueToInfiniteRecursion();
    }

    public void DrawRecursiveSandClock(int height)
    {
        // Bottom of recursion
        if (height == 0)
        {
            return;
        }

        // Pre-action
        Console.WriteLine(new String('*', height));

        // Recursion
        DrawRecursiveSandClock(height - 1);

        // Post-action
        Console.WriteLine(new String('#', height));
    }

    public void PrintFibonacciNumbersForever(int previous = 1, int beforePrevious = 1)
    {
        int current = previous + beforePrevious;

        Console.WriteLine(previous);

        Thread.Sleep(500);

        // WARNING: No bottom of recursion
        PrintFibonacciNumbersForever(current, previous);
    }

    public void PrintFibonacciNumbers(int countStopper, int previous = 1, int beforePrevious = 1)
    {
        // Initial member equals 1.
        if (previous == 1 && beforePrevious == 1)
        {
            Console.WriteLine(previous);
        }

        if (countStopper == 1)
        {
            return;
        }

        int current = previous + beforePrevious;

        Console.WriteLine(previous);

        Thread.Sleep(500);

        PrintFibonacciNumbers(--countStopper, current, previous);
    }

    public void GenerateRandomStringRecursively(StringBuilder input, int stopper)
    {
        // Bottom of recursion
        if (input.Length == stopper)
        {
            return;
        }

        input.Append((char)_random.Next(65, 90));

        GenerateRandomStringRecursively(input, stopper);
    }

    public void PrintBinaryNumbers(int[] vector, int index = 0)
    {
        // Bottom of recursion
        if (vector.Length == index)
        {
            Console.WriteLine(String.Join(" ", vector));
            return;
        }

        for (int i = 0; i <= 1; i++)
        {
            vector[index] = i;
            PrintBinaryNumbers(vector, index + 1);
        }
    }
}
