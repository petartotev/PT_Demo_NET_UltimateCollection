using Ionic.Zlib;
using System.Text;

namespace DemoIonicZlibCore.Extensions;

public static class ZlibExtensions
{
    private const string ZlibHeader = "789c";

    // ========================= Compress =========================
    public static byte[] CompressToBytes(this string input)
    {
        var bytesDecompressed = Encoding.UTF8.GetBytes(input);
        var bytesCompressed = CompressBytes(bytesDecompressed);
        return bytesCompressed;
    }

    private static byte[] CompressBytes(byte[] bytes)
    {
        // IDE0063 'using' statement can be simplified
        // WARNING: Do not 'simplify' - stream scope changes and compression doesn't work!
        using (var output = new MemoryStream())
        {
            using (var zlibStream = new ZlibStream(output, CompressionMode.Compress))
            {
                zlibStream.Write(bytes);
            }

            return output.ToArray();
        }
    }

    // ========================= Decompress =========================
    public static string DecompressToString(this byte[] bytes)
    {
        var bytesDecompressed = DecompressBytes(bytes);
        var stringOutput = Encoding.UTF8.GetString(bytesDecompressed);
        return stringOutput;
    }

    private static byte[] DecompressBytes(byte[] bytes)
    {
        // IDE0063 'using' statement can be simplified
        // WARNING: Do not 'simplify' - stream scope changes and decompression doesn't work!
        using (var output = new MemoryStream())
        {
            using (var zlibStream = new ZlibStream(output, CompressionMode.Decompress))
            {
                zlibStream.Write(bytes);
            }
            return output.ToArray();
        }
    }

    // ========================= Zlib > ByteArray =========================
    public static byte[] ConvertZlibStringToByteArray(this string zlibString)
    {
        if (!zlibString.IsZlibString()) throw new ArgumentException("The input string is not in a valid ZLIB format.");

        var byteArray = new byte[zlibString.Length / 2];

        for (var i = 0; i < zlibString.Length; i += 2)
        {
            byteArray[i / 2] = Convert.ToByte(zlibString.Substring(i, 2), 16);
        }

        return byteArray;
    }

    private static bool IsZlibString(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && input.StartsWith(ZlibHeader, StringComparison.OrdinalIgnoreCase) && input.Length % 2 == 0;
    }

    // ========================= ByteArray > Zlib =========================
    public static string ConvertByteArrayToZlibString(this byte[] bytes)
    {
        return bytes.ToHex();
    }

    private static string ToHex(this byte[] hashBytes, bool upper = false)
    {
        var len = hashBytes.Length * 2;
        var chars = new char[len];
        var index = 0;
        for (int i = 0; i < len; i += 2)
        {
            var b = hashBytes[index++];
            chars[i] = GetHexValue(b / 16, upper);
            chars[i + 1] = GetHexValue(b % 16, upper);
        }
        return new string(chars);
    }

    private static char GetHexValue(int i, bool upper)
    {
        if (i < 0 || i > 15)
            throw new ArgumentOutOfRangeException(nameof(i), "must be between 0 and 15");

        return i < 10
            ? (char)(i + '0')
            : (char)(i - 10 + (upper ? 'A' : 'a'));
    }
}
