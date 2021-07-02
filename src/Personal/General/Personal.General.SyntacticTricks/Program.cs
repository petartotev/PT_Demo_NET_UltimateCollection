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

            // Multiple declaration of the same type on a single line.
            decimal dec1 = 9.51M, dec2 = 1.24M, dec3 = 3.33M;
            Console.WriteLine(string.Concat(dec1, dec2, dec3));

            GC.Collect();


        }

        public static IEnumerable<string> ReturnEmptyEnumerable()
        {
            return Enumerable.Empty<string>();
        }
    }
}
