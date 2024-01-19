using Personal.General.InterfacesExplicitImplicit.Models.Interfaces;

namespace Personal.General.InterfacesExplicitImplicit.Models;

public class Person : IMate, IMan
{
    void IMate.Do()
    {
        Console.WriteLine("IMate does it.");
    }

    void IMan.Do()
    {
        Console.WriteLine("IMan does it.");
    }

    public void Do()
    {
        Console.WriteLine("Person does it.");
    }
}
