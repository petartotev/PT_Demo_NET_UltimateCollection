using Personal.Algorithms.Recursion.Models;
using System.Text;

RecursionGenerator myRecursionGenerator = new();

//myRecursionGenerator.InvokeStackOverflowDueToInfiniteRecursion();

myRecursionGenerator.DrawRecursiveSandClock(height: 12);

myRecursionGenerator.PrintFibonacciNumbers(5);

//myRecursionGenerator.PrintFibonacciNumbersForever();

var stringMaster = new StringBuilder();
myRecursionGenerator.GenerateRandomStringRecursively(stringMaster, 36);
Console.WriteLine(stringMaster);

myRecursionGenerator.PrintBinaryNumbers(new int[] { 0, 0, 0 });