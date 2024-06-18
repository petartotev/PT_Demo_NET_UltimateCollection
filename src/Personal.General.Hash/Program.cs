using Personal.General.Hash.Helpers;
using Personal.General.Hash.Models;

namespace Personal.General.Hash;

public class Program
{
    public static void Main()
    {
        var thingShortToHash = "Hello, World!";
        var thingLongToHash = "Hello, my beautiful, colorful, wonderful, friendly World!";

        // ======================================== MD5 Hashing Algorithm ========================================
        var hashMd5ThingShort = HashHelper.ComputeMd5Hash(thingShortToHash);
        var hashMd5ThingLong = HashHelper.ComputeMd5Hash(thingLongToHash);
        // 65a8e27d8879283831b664bd8b7f0ad4
        Console.WriteLine("Hash MD5     Short String: " + hashMd5ThingShort);
        // 74bd64a9dd5951b504955c163762f96e
        Console.WriteLine("Hash MD5      Long String: " + hashMd5ThingLong);

        // ======================================== SHA-1 Hashing Algorithm ========================================
        var hashSha1ThingShort = HashHelper.ComputeSha1Hash(thingShortToHash);
        var hashSha1ThingLong = HashHelper.ComputeSha1Hash(thingLongToHash);
        // 0a0a9f2a6772942557ab5355d76af442f8f65e01
        Console.WriteLine("Hash SHA-1   Short String: " + hashSha1ThingShort);
        // a84b8d5a1299c958d5c7d329d773ac863093f7fb
        Console.WriteLine("Hash SHA-1    Long String: " + hashSha1ThingLong);

        // ======================================== SHA-256 Hashing Algorithm ========================================
        var hashSha256ThingShort = HashHelper.ComputeSha256Hash(thingShortToHash);
        var hashSha256ThingLong = HashHelper.ComputeSha256Hash(thingLongToHash);
        // dffd6021bb2bd5b0af676290809ec3a53191dd81c7f70a4b28688a362182986f
        Console.WriteLine("Hash SHA-256 Short String: " + hashSha256ThingShort);
        // fe0615d062ab24332a250172dd6b67a3c20730d510b9fc179d83938ffd358a25
        Console.WriteLine("Hash SHA-256  Long String: " + hashSha256ThingLong);

        // ======================================== SHA-384 Hashing Algorithm ========================================
        var hashSha384ThingShort = HashHelper.ComputeSha384Hash(thingShortToHash);
        var hashSha384ThingLong = HashHelper.ComputeSha384Hash(thingLongToHash);
        // 5485cc9b3365b4305dfb4e8337e0a598a574f8242bf17289e0dd6c20a3cd44a089de16ab4ab308f63e44b1170eb5f515
        Console.WriteLine("Hash SHA-384 Short String: " + hashSha384ThingShort);
        // b1606df073de8852694ff59c8086a35f4c9f05d2f0753e2d86f284a235e4720c971bcc0fd41c953dbb55a8e8505c2886
        Console.WriteLine("Hash SHA-384  Long String: " + hashSha384ThingLong);

        // ======================================== SHA-512 Hashing Algorithm ========================================
        var hashSha512ThingShort = HashHelper.ComputeSha512Hash(thingShortToHash);
        var hashSha512ThingLong = HashHelper.ComputeSha512Hash(thingLongToHash);
        // 374d794a95cdcfd8b35993185fef9ba368f160d8daf432d08ba9f1ed1e5abe6cc69291e0fa2fe0006a52570ef18c19def4e617c33ce52ef0a6e5fbe318cb0387
        Console.WriteLine("Hash SHA-512 Short String: " + hashSha512ThingShort);
        // c61b28929f0a3b5a78933c9c0138ad3407206c83130eaa9d260cce5d7ede21d82556d2b146566131aa545dfc2682ef940e2c9bb82eaa07e826c5aca20ae82332
        Console.WriteLine("Hash SHA-512  Long String: " + hashSha512ThingLong);

        // ======================================== Simple Hash Table ========================================
        var hashTable = new SimpleHashTable<string, string>();
        hashTable.Add("key1", "Hello!");
        hashTable.Add("key2", "World!");

        Console.WriteLine($"Value for 'key1': {hashTable.Get("key1")}");
        Console.WriteLine($"Value for 'key2': {hashTable.Get("key2")}");

        // ======================================== GetHashCode ========================================
        var person1 = new PersonHashDefault
        {
            FirstName = "Petar",
            LastName = "Totev",
            DateOfBirth = DateTime.Now.AddYears(-34),
            Email = "petar@petartotev.net"
        };

        // 43942917
        var person1HashCode = person1.GetHashCode();
        Console.WriteLine("person1 Hash Code: " + person1HashCode);

        var person2 = new PersonHashOverridden
        {
            FirstName = "Petar",
            LastName = "Totev",
            DateOfBirth = DateTime.Now.AddYears(-34),
            Email = "petar@petartotev.net"
        };

        // -1380672416
        // Hash codes in .NET are represented as signed 32-bit integers => range of possible values: from -2,147,483,648 to 2,147,483,647.
        // When using the HashCode.Combine method or even when manually combining hash codes, the resulting integer can fall anywhere within this range.
        var person2HashCode = person2.GetHashCode();
        Console.WriteLine("person2 Hash Code: " + person2HashCode);
    }
}
