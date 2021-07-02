namespace Personal.OOP.DemoStaticConstructor
{
    public class Program
    {
        static void Main()
        {
            // 3 objects created, static constructor called only once, before initializing the first object of this class.
            ClassHavingStaticCtor myObject1 = new ClassHavingStaticCtor(nameof(myObject1));
            ClassHavingStaticCtor myObject2 = new ClassHavingStaticCtor(nameof(myObject2));
            ClassHavingStaticCtor myObject3 = new ClassHavingStaticCtor(nameof(myObject3));
        }
    }
}
