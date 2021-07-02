using System;

namespace Personal.OOP.AbstractVirtual
{
    public class DerivedClass : AbstractClass
    {
        // CS0513: 'function' is abstract but it is contained in nonabstract class 'class'  
        // A method cannot be an abstract member of a non-abstract class.

        //public abstract void AbstractVoid();

        // You can have a virtual method in a public class
        public virtual void VirtualMethodInPublicClass()
        {
            throw new NotImplementedException();
        }

        // MUST IMPLEMENT!!!
        public override void AbstractMethodNoLogicImplemented()
        {
            throw new NotImplementedException();
        }

        // You can either override the virtual method or not...
        public override void VirtualMethodLogicImplemented()
        {
            base.VirtualMethodLogicImplemented();
        }
    }
}
