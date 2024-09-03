# PT_Demo_NET_UltimateCollection

PT_Demo_NET_UltimateCollection is an ultimate collection of demos, tests, examples and new features for .NET (C#).

# Contents
- [Personal](#personal)
    - [Async](#async)
    - [Dapper](#dapper)
    - [General](#general)
        - [Dependency Injection](#personalgeneraldependencyinjection)
    - [OOP](#oop)
- [SQL](#sql)
    - [BulkInsert](#sqlserverbulkinsert)
        - [Initial Setup](#initial-setup)
        - [Implementation and Execution](#implementation-and-execution)
- [Using](#using)
    - [FakeItEasy](#demofakeiteasy-fakeiteasy-810)
    - [FuzzySharp](#demofuzzysharp-fuzzysharp-202)
    - [Ionic.Zlib.Core](#demoioniczlibcore-ioniczlibcore-100)
    - [RulesEngine](#demorulesengine-rulesengine-503)
- [Links](#links)

# Personal

## Async

### Personal.Async.AsyncAwait
### Personal.Async.Pluralsight.Article.1.TPL
### Personal.Async.Pluralsight.Article.2.AsyncAwait
### Personal.Async.Pluralsight.Article.3.ControlFlow
### Personal.Async.Pluralsight.Article.4.AsyncTaskRun
### Personal.Async.Pluralsight.Article.5.AsyncTaskRun
### Personal.Async.Semaphore
### Personal.Async.Synchronous
### Personal.Async.TaskCancellation
### Personal.Async.TaskRun
### Personal.Async.ThreadNew
### Personal.Async.ThreadsDeadlock
### Personal.Async.WpfDemo

## Dapper

### CarDemo.Console
### CarDemo.Data
### CarDemo.Data.Models
### CarDemo.Services
### CarDemo.Services.Models
### CarDemo.Services.Tests
### CarDemo.Web

## General

### Personal.General.DependencyInjection

1. Create new blank .NET 8 Console Application.

2. Install NuGet `Microsoft.Extensions.DependencyInjection`.

3. Create interfaces and their respective classes:
- `ITeacherService`-`TeacherService`;
- `IParentService`-`ParentService`;
- `IStudentService`-`StudentService`, injecting IParentService in its constructor.

4. In Program.cs, create new ServiceProvider:

```
    public static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IStudentService, StudentService>()
            .AddTransient<ITeacherService, TeacherService>()
            .AddScoped<IParentService, ParentService>()
            .BuildServiceProvider();

        var student1 = serviceProvider.GetService<IStudentService>();
        student1.Study();

        var teacher1 = serviceProvider.GetService<ITeacherService>();
        var teacher2 = serviceProvider.GetService<ITeacherService>();
        Console.WriteLine($"Transient Test: Are teacher1 and teacher2 the same instance? {teacher1 == teacher2}");

        using (var scope1 = serviceProvider.CreateScope())
        {
            var parent1 = scope1.ServiceProvider.GetService<IParentService>();
            var parent2 = scope1.ServiceProvider.GetService<IParentService>();
            Console.WriteLine($"Scoped Test (within scope1): Are parent1 and parent2 the same instance? {parent1 == parent2}");
        }

        using (var scope2 = serviceProvider.CreateScope())
        {
            var parent3 = scope2.ServiceProvider.GetService<IParentService>();
            Console.WriteLine($"Scoped Test (across scopes): Are parent2 and parent3 the same instance? {parent3 == serviceProvider.GetService<IParentService>()}");
        }
    }
```

### Personal.General.EncapsulationVsReflection
### Personal.General.FuncActionPredicate
### Personal.General.InterfacesExplicitImplicit
### Personal.General.jQueryTricks
### Personal.General.SyntacticTricks

## OOP

### Personal.OOP.DemoAbstractVirtual
### Personal.OOP.DemoEncapsulation
### Personal.OOP.DemoEncapsulationLib1
### Personal.OOP.DemoStaticConstructor

## SQL

### SqlServerBulkInsert

#### Initial Setup

1. Open MSSMS and create a new empty database `Northwind`:

```
CREATE DATABASE Northwind
GO
```

2. Execute `instnwnd.sql` and `instpubs.sql` - either [downloaded from here](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs) or using the files stored locally in the `/res` directory of this project.<br>
This will build the `Northwind` database (recommended as [a sample database](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/downloading-sample-databases) by Microsoft and seed data in it.

#### Implementation and Execution

1. Install the following NuGet package:

```
dotnet add package System.Data.SqlClient
```

2. Implement the codebase as it is in the repository.

3. Execute the application with `SqlManager.DeleteRowsCreatedHere()` commented out in `Main()`.

## Using

### DemoFakeItEasy (FakeItEasy 8.1.0)
Demo uses [FakeItEasy library](https://fakeiteasy.github.io/) which seems to be a good alternative to Moq.

### DemoFuzzySharp (FuzzySharp 2.0.2)
Demo implements Fuzzy Matching using [FuzzySharp library](https://github.com/JakeBayer/FuzzySharp).

### DemoIonicZlibCore (Ionic.Zlib.Core 1.0.0)
Demo uses [Ionic.Zlib.Core library](https://www.nuget.org/packages/Ionic.Zlib.Core/) which lets you compress and decompress ZLIB-formatted strings.

### DemoRulesEngine (RulesEngine 5.0.3)
Demo uses [RulesEngine library](https://github.com/microsoft/RulesEngine).

## Links
- https://makolyte.com/csharp-how-to-use-sqlbulkcopy-to-do-a-bulk-insert/
- https://github.com/JakeBayer/FuzzySharp
- https://github.com/microsoft/RulesEngine
