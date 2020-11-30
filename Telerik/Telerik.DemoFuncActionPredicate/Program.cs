using System;

namespace Telerik.DemoFuncActionPredicate
{
    public class Program
    {
        static void Main(string[] args)
        {            
            Func<int, int> myFunc1 = x => x * 2;

            int num = 2;
            PrintFunc1ArgResult(myFunc1, num);

            int num1 = 3;
            int num2 = 5;
            Func<int, int, int> myFunc2 = (x, y) => x + y;
            PrintFunc2ArgsResult(myFunc2, num1, num2);

            Action<string> myAction1 = x => Console.WriteLine($"An action receives an argument {x} and prints it with Console.WriteLine().");
            myAction1("Test");

            Predicate<int> myPredicate1 = x => x > 5;
            Console.WriteLine($"A predicate receives an integer and evaluates if (the integer > 5) and returns true/false. Here is the result: " + myPredicate1(7));
        }

        static void PrintFunc1ArgResult(Func<int, int> func, int num)
        {
            Console.Write($"This is the result of a func that receives an arg ({num}) and multiplies it by 2: ");
            Console.WriteLine(func(num));
        }

        static void PrintFunc2ArgsResult(Func<int, int, int> func, int num1, int num2)
        {
            Console.Write($"This is the result of a func that receives 2 args ({num1} and {num2}) and sums them: ");
            Console.WriteLine(func(num1, num2));
        }
    }
}
