using System;
using System.Collections.Generic;
using System.Linq;

namespace Personal.General.DemoSyntacticTricks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Empty char.
            char myChar = '\0';
            Console.WriteLine(myChar);

            // '_' makes the integer more readable.
            int myNum = 1_500_000;
            Console.WriteLine(myNum);

            ReturnEmptyEnumerable();
        }

        public static IEnumerable<string> ReturnEmptyEnumerable()
        {
            return Enumerable.Empty<string>();
        }
    }
}
