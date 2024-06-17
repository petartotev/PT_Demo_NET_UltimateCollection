using System.Security.Cryptography;
using System.Text;

namespace Personal.General.Hash;

public static class HashHelper
{
    public static string ComputeMd5Hash(string rawData)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            return ConvertToHexString(bytes);
        }
    }

    public static string ComputeSha1Hash(string rawData)
    {
        using (SHA1 sha1Hash = SHA1.Create())
        {
            byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            return ConvertToHexString(bytes);
        }
    }

    public static string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            return ConvertToHexString(bytes);
        }
    }

    public static string ComputeSha384Hash(string rawData)
    {
        using (SHA384 sha384Hash = SHA384.Create())
        {
            byte[] bytes = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            return ConvertToHexString(bytes);
        }
    }

    public static string ComputeSha512Hash(string rawData)
    {
        using (SHA512 sha512Hash = SHA512.Create())
        {
            byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            return ConvertToHexString(bytes);
        }
    }

    // ================================================== Private Methods ==================================================
    private static string ConvertToHexString(byte[] bytes)
    {
        var builder = new StringBuilder();

        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}
