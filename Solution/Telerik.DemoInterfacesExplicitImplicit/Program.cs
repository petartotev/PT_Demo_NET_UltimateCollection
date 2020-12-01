using System;
using Telerik.DemoInterfacesExplicitImplicit.Contracts;

namespace Telerik.DemoInterfacesExplicitImplicit
{
    public class Program
    {
        static void Main(string[] args)
        {
            // EXPLICITLY AND IMPLICITLY IMPLEMENTED INTERFACES
            IMate myMate = new Person();
            IMan myMan = new Person();
            Person myPerson = new Person();

            myMate.Do(); // IMate does.
            myMan.Do(); // IMan does.
            myPerson.Do(); // Person does.
        }
    }
}
