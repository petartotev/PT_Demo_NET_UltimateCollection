# PT_Demo_UltimateCollection

PT_Demo_UltimateCollection is an ultimate collection of demos, tests, examples and new features for .NET/C#.

## Contents
- [Solution](#solution)
    - [Personal](#personal)
        - [Async](#async)
        - [Dapper](#dapper)
        - [General](#general)
        - [OOP](#oop)
    - [SQL](#sql)
        - [BulkInsert](#sqlserverbulkinsert)
            - [Initial Setup](#initial-setup)
            - [Implementation and Execution](#implementation-and-execution)
    - [Using](#using)
        - [FuzzySharp](#demofuzzysharp-fuzzysharp-202)
        - [RulesEngine](#demorulesengine-rulesengine-503)
- [Links](#links)

## Solution

## *Personal*

### Async
- Personal.Async.AsyncAwait
- Personal.Async.Pluralsight.Article.1.TPL
- Personal.Async.Pluralsight.Article.2.AsyncAwait
- Personal.Async.Pluralsight.Article.3.ControlFlow
- Personal.Async.Pluralsight.Article.4.AsyncTaskRun
- Personal.Async.Pluralsight.Article.5.AsyncTaskRun
- Personal.Async.Semaphore
- Personal.Async.Synchronous
- Personal.Async.TaskCancellation
- Personal.Async.TaskRun
- Personal.Async.ThreadNew
- Personal.Async.ThreadsDeadlock
- Personal.Async.WpfDemo

### Dapper
- CarDemo.Console
- CarDemo.Data
- CarDemo.Data.Models
- CarDemo.Services
- CarDemo.Services.Models
- CarDemo.Services.Tests
- CarDemo.Web

### General
- Personal.General.EncapsulationVsReflection
- Personal.General.FuncActionPredicate
- Personal.General.InterfacesExplicitImplicit
- Personal.General.jQueryTricks
- Personal.General.SyntacticTricks

### OOP
- Personal.OOP.DemoAbstractVirtual
- Personal.OOP.DemoEncapsulation
- Personal.OOP.DemoEncapsulationLib1
- Personal.OOP.DemoStaticConstructor

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

## *Using*

### DemoFuzzySharp (FuzzySharp 2.0.2)
Demo implements Fuzzy Matching using [FuzzySharp library](https://github.com/JakeBayer/FuzzySharp).

### DemoRulesEngine (RulesEngine 5.0.3)
Demo uses [RulesEngine library](https://github.com/microsoft/RulesEngine).

## Links
- https://makolyte.com/csharp-how-to-use-sqlbulkcopy-to-do-a-bulk-insert/
- https://github.com/JakeBayer/FuzzySharp
- https://github.com/microsoft/RulesEngine