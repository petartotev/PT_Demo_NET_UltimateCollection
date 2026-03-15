using System.IO.Hashing;
using System.Text;

namespace Personal.General.Hash.Models;

public class SamplingPercent
{
    public static void PlayWithUserCriteria()
    {
        var users = new List<int>();
        var abTestingGroups = new Dictionary<int, List<int>>();

        // Let's produce 1000 random Users:
        for (int i = 0; i < 1000; i++)
        {
            // Try until you generate an unique user.
            int user;
            while (true)
            {
                user = Random.Shared.Next(0, int.MaxValue);

                if (!users.Contains(user))
                    break;
            }

            users.Add(user);
            var abGroup = CalculateUserCriteriaHash(user);

            if (!abTestingGroups.TryGetValue(abGroup, out List<int> value))
            {
                value = ([]);
                abTestingGroups[abGroup] = value;
            }

            value.Add(user);
        }

        abTestingGroups = abTestingGroups.OrderBy(x => x.Key).ToDictionary();

        foreach (var group in abTestingGroups)
        {
            Console.WriteLine("KEY " + group.Key);
            for (int i = 0; i < group.Value.Count; i++)
            {
                Console.WriteLine(group.Value[i]);
            }
        }
    }

    private static int CalculateUserCriteriaHash(int userId)
    {
        try
        {
            var bytes = Encoding.UTF8.GetBytes(userId.ToString());
            uint hash = XxHash32.HashToUInt32(bytes);

            return (int)(hash % 100);
        }
        catch (Exception)
        {
            return -1;
        }
    }
}
