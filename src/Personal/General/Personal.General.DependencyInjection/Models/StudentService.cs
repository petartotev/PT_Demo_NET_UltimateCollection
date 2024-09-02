using Personal.General.DependencyInjection.Models.Interfaces;

namespace Personal.General.DependencyInjection.Models
{
    public class StudentService : IStudentService
    {
        private readonly IParentService _parentService;

        public StudentService(IParentService parentService)
        {
            _parentService = parentService;
        }

        public void Study()
        {
            Console.WriteLine("Student studies!");
            _parentService.Support();
        }
    }
}
