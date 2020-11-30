namespace Personal.OOP.DemoEncapsulationLib1
{
    public class AnotherClass
    {
        private ParentClass newClass = new ParentClass();

        // PROTECTED
        // ParentClass has a protected method ProtectedMethod().
        // But we cannot access it from AnotherClass as AnotherClass does not inherit ParentClass...
        public void Method()
        {
            //newClass.ProtectedMethod();
        }
    }
}
