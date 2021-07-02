namespace Personal.OOP.DemoEncapsulationLib1
{
    class ChildClass : ParentClass
    {
        public void Method()
        {
            // We can use the protected method from ParentClass
            base.ProtectedMethod();
        }
    }
}
