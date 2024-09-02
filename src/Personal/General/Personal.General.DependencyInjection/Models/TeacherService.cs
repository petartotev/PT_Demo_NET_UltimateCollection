using Personal.General.DependencyInjection.Models.Interfaces;

namespace Personal.General.DependencyInjection.Models
{
    internal class TeacherService : ITeacherService
    {
        public void Teach()
        {
            Console.WriteLine("Teacher teaches!");
        }
    }
}
