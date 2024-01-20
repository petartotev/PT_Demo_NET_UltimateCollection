using DemoIonicZlibCore.Extensions;

namespace DemoIonicZlibCore;

public class Program
{
    public static void Main()
    {
        // Zlib => String
        var zlibToConvert = "789c0bc9c82c56c82c56485428492d2e510400298a0517";

        var stringConverted = zlibToConvert
            .ConvertZlibStringToByteArray()
            .DecompressToString();

        Console.WriteLine(stringConverted); // This is a test!

        // String => Zlib
        var stringToConvert = "This is a test!";

        var zlibResult = stringToConvert
            .CompressToBytes()
            .ConvertByteArrayToZlibString();

        Console.WriteLine(zlibResult); // 789c0bc9c82c5600a2448592d4e2124500298a0517

        // Note that the 2 zlib-s don't match:
        Console.WriteLine($"zlibToConvert = zlibResult: {zlibToConvert == zlibResult}");
    }
}