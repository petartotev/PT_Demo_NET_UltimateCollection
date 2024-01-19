using System;

namespace Personal.OOP.AbstractVirtual
{
    public abstract class AbstractClass
    {
        public abstract void AbstractMethodNoLogicImplemented();

        // CS0500 : 'class member' cannot declare a body because it is marked abstract.
        // Abstract methods cannot contain implementation!

        //public abstract void AbstractMethodLogicImplemented()
        //{
        //    Console.WriteLine("Logic implemented.");
        //}

        public virtual void VirtualMethodLogicImplemented()
        {
            Console.WriteLine("Your logic here.");
        }

        // CS0501: 'member function' must declare a body because it is not marked abstract, extern, or partial.
        // Non-Abstract methods must have implementation!

        //public virtual void VirtualMethodNoLogicImplemented();
    }
}
