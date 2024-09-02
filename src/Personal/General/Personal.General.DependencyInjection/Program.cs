using Microsoft.Extensions.DependencyInjection;
using Personal.General.DependencyInjection.Models;
using Personal.General.DependencyInjection.Models.Interfaces;

namespace Personal.General.DependencyInjection;

public class Program
{
    public static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IStudentService, StudentService>()
            .AddTransient<ITeacherService, TeacherService>()
            .AddScoped<IParentService, ParentService>()
            .BuildServiceProvider();

        // Demonstrating Singleton
        var student1 = serviceProvider.GetService<IStudentService>();
        student1.Study();

        // Demonstrating Transient
        var teacher1 = serviceProvider.GetService<ITeacherService>();
        var teacher2 = serviceProvider.GetService<ITeacherService>();

        Console.WriteLine($"Transient Test: Are teacher1 and teacher2 the same instance? " +
            $"{teacher1 == teacher2}");

        // Demonstrating Scoped
        using (var scope1 = serviceProvider.CreateScope())
        {
            var parent1 = scope1.ServiceProvider.GetService<IParentService>();
            var parent2 = scope1.ServiceProvider.GetService<IParentService>();

            Console.WriteLine($"Scoped Test (within scope1): Are parent1 and parent2 the same instance? " +
                $"{parent1 == parent2}");
        }

        using (var scope2 = serviceProvider.CreateScope())
        {
            var parent3 = scope2.ServiceProvider.GetService<IParentService>();

            Console.WriteLine($"Scoped Test (across scopes): Are parent2 and parent3 the same instance? " +
                $"{parent3 == serviceProvider.GetService<IParentService>()}");
        }
    }
}
