namespace Personal.OOP.DemoStaticConstructor
{
    public class Program
    {
        static void Main()
        {
            // 3 objects were created, but static constructor was called only once, before the first object of this class was initialized.
            ClassHavingStaticCtor myObject1 = new ClassHavingStaticCtor(nameof(myObject1));
            ClassHavingStaticCtor myObject2 = new ClassHavingStaticCtor(nameof(myObject2));
            ClassHavingStaticCtor myObject3 = new ClassHavingStaticCtor(nameof(myObject3));
        }
    }
}
