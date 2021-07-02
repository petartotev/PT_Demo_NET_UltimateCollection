using System;

namespace Personal.OOP.DemoStaticConstructor
{
    public class Program
    {
        static void Main(string[] args)
        {
            ClassHavingStaticCtor myObject1 = new ClassHavingStaticCtor();
            ClassHavingStaticCtor myObject2 = new ClassHavingStaticCtor();
            ClassHavingStaticCtor myObject3 = new ClassHavingStaticCtor();

            // 3 objects created, static constructor called only once, before initializing the first object of this class.
        }
    }
}
