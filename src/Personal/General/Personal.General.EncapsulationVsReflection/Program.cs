using System.Reflection;

namespace Personal.General.EncapsulationVsReflection
{
    public class Program
    {
        static void Main()
        {
            Textbook myTexbook = new Textbook();

            MethodInfo myMethodInfo = myTexbook.GetType().GetMethod("Read", BindingFlags.NonPublic | BindingFlags.Instance);

            myMethodInfo.Invoke(myTexbook, null);
        }
    }
}
