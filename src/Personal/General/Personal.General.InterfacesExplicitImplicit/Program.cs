using Personal.General.InterfacesExplicitImplicit.Models;
using Personal.General.InterfacesExplicitImplicit.Models.Interfaces;

namespace Personal.General.InterfacesExplicitImplicit;

// Explicitly and Implicitly implemented Interfaces:
public class Program
{
    public static void Main()
    {
        IMate myMate = new Person();
        IMan myMan = new Person();
        Person myPerson = new Person();

        myMate.Do(); // IMate does.
        myMan.Do(); // IMan does.
        myPerson.Do(); // Person does.
    }
}