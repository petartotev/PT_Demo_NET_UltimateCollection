public class OperatorsManager
{
    public bool ExecuteAndReturnTrue()
    {
        PrintFunctionExecuted(nameof(ExecuteAndReturnTrue));
        return true;
    }

    public bool ExecuteAndReturnFalse()
    {
        PrintFunctionExecuted(nameof(ExecuteAndReturnFalse));
        return false;
    }

    private static void PrintFunctionExecuted(string functionName)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Printed by {functionName}.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}