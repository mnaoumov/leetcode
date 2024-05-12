using JetBrains.Annotations;

namespace LeetCode._0093_Restore_IP_Addresses;

/// <summary>
/// https://leetcode.com/submissions/detail/829112718/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> RestoreIpAddresses(string s)
    {
        return Get(0, 4).ToArray();

        IEnumerable<string> Get(int index, int partsCount)
        {
            if (index == s.Length)
            {
                if (partsCount == 0)
                {
                    yield return "";
                }

                yield break;

            }

            var digit = GetDigit(index);

            foreach (var rest in Get(index + 1, partsCount - 1))
            {
                yield return ConstructIp(1, rest);
            }

            if (index + 1 < s.Length && digit > 0)
            {
                foreach (var rest in Get(index + 2, partsCount - 1))
                {
                    yield return ConstructIp(2, rest);
                }
            }

            if (index + 2 < s.Length && digit is 1 or 2)
            {
                var nextDigit = GetDigit(index + 1);
                var nextNextDigit = GetDigit(index + 2);
                if (digit == 1 || nextDigit < 5 || nextDigit == 5 && nextNextDigit <= 5)
                {
                    foreach (var rest in Get(index + 3, partsCount - 1))
                    {
                        yield return ConstructIp(3, rest);
                    }
                }
            }

            yield break;

            string ConstructIp(int length, string rest)
            {
                var part1 = s[index..(index + length)];
                return rest == "" ? part1 : $"{part1}.{rest}";
            }
        }

        int GetDigit(int index)
        {
            return s[index] - '0';
        }
    }
}
