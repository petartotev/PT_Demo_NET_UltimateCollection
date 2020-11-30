using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.OOP.DemoEncapsulationLib1
{
    public class ParentClass
    {
        private InternalClass internalClass = new InternalClass();

        protected void ProtectedMethod()
        {
            Console.WriteLine("This is a protected method");
        }
    }
}
