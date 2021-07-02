using System;
using Telerik.DemoInterfacesExplicitImplicit.Contracts;

namespace Telerik.DemoInterfacesExplicitImplicit
{
    public class Person : IMate, IMan
    {
        void IMate.Do()
        {
            Console.WriteLine("I Mate Does.");
        }

        void IMan.Do()
        {
            Console.WriteLine("I Man Does.");
        }

        public void Do()
        {
            Console.WriteLine("Person Does.");
        }
    }
}
