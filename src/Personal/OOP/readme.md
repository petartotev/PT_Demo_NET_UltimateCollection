# Abstract methods can exist ONLY in Abstract classes!

CS0513: 'function' is abstract but it is contained in nonabstract class 'class'  
A method cannot be an abstract member of a non-abstract class.

public class clx {  
 abstract public void f(); // CS0513  
}

# Abstract methods CANNOT contain any logic!

CS0500 : 'class member' cannot declare a body because it is marked abstract  
An abstract method cannot contain its implementation.

abstract public class clx {  
 abstract public void f(){} // CS0500  
 abstract public void f(); // try the following line instead  
 }

# Virtual methods MUST have logic!

CS0501: 'member function' must declare a body because it is not marked abstract, extern, or partial.  
Nonabstract methods must have implementations.

public class clx {  
 public void f(); // CS0501  
 public void g() {} // OK  
}

# Virtual methods can exist in both normal and abstract classes!

public class NormalClass {  
public virtual void VirtualMethodInPublicClass()  
{  
throw new NotImplementedException();  
}  
}

public abstract class AbstractClass
{
public virtual void VirtualMethodLogicImplemented()  
{  
Console.WriteLine("Your logic here.");  
}  
}

# Classes cannot be declared as private, protected, protected internal or private protected!

CS1527: Elements defined in a namespace cannot be explicitly declared as private, protected, protected internal or private protected.  
Type declarations in a namespace can have either public or internal access. If no accessibility is specified, internal is the default.

namespace Sample  
{  
 private class C1 {} // CS1527  
 protected class C2 {} // CS1527  
 protected internal class C3 {} // CS1527  
 private protected class C4 {} // CS1527  
}

# Here is what Protected is used for

public class ParentClass  
{  
 protected void ProtectedMethod()  
{  
Console.WriteLine("This is a protected method");  
}  
}

class ChildClass : ParentClass  
{  
public void Method()  
{  
// We can use the protected method from ParentClass  
base.ProtectedMethod();  
}  
}

public class AnotherClass  
{  
private ParentClass newClass = new ParentClass();  
public void Method()  
{  
// newClass\.ProtectedMethod();  
// YOU CANNOT SEE THE PROTECTED METHOD HERE AS THE CLASS DOES NOT DERIVE FROM PARENT CLASS!  
}  
}

# Access modifiers are not allowed on static constructors!

CS015: 'function' : access modifiers are not allowed on static constructors  
A static constructor cannot have an access modifier.

public class Classy  
{  
public static ClassHavingStaticCtor() // CS015  
{  
Console.WriteLine("This will be executed only once!");  
}  
}  


