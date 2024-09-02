using Personal.General.DependencyInjection.Models.Interfaces;

namespace Personal.General.DependencyInjection.Models
{
    public class ParentService : IParentService
    {
        public void Support()
        {
            Console.WriteLine("Parent supports!");
        }
    }
}
