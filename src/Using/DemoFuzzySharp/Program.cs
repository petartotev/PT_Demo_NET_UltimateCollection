using FuzzySharp;

namespace DemoFuzzySharp;

// https://github.com/JakeBayer/FuzzySharp
public class Program
{
    private const string Original = "Petar Totev";

    public static void Main()
    {

        var alternatives = new string[] { "PT", "P T", "Poo Tea", "Pipi Tooth", "Pepka Totka", "Petio Toteff", "P3tar T0t3v", "Petarcho Totevich", "petar totev", "Petar Totev" };

        foreach (var alternative in alternatives)
        {
            Calculate(alternative);
        }
    }

    private static void Calculate(string input)
    {
        var pTyResult = Fuzz.Ratio(Original, input);
        Console.WriteLine($"{pTyResult:d3} | {Original} vs {input}");
    }
}