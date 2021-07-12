using Telerik.DemoInterfacesExplicitImplicit.Contracts;

namespace Telerik.DemoInterfacesExplicitImplicit
{
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
}
