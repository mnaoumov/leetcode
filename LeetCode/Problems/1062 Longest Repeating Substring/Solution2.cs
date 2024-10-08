using System.Numerics;

namespace LeetCode.Problems._1062_Longest_Repeating_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/951612553/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestRepeatingSubstring(string s)
    {
        var low = 1;
        var high = s.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (HasRepeatingSubstring(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool HasRepeatingSubstring(int length)
        {
            const int modulo = 80_000_000;
            const int @base = 26;
            const char firstLetter = 'a';
            var biggestPower = (int) BigInteger.ModPow(@base, length - 1, modulo);

            var hashes = new HashSet<int>();

            var hash = 0;

            for (var i = 0; i < length; i++)
            {
                hash = (@base * hash + (s[i] - firstLetter)) % modulo;
            }

            hashes.Add(hash);

            for (var i = 1; i <= s.Length - length; i++)
            {
                var previousOffset = s[i - 1] - 'a';
                var nextOffset = s[i + length - 1] - 'a';
                hash = ((hash - previousOffset * biggestPower) % modulo + modulo) % modulo;
                hash = (hash * @base + nextOffset) % modulo;

                if (!hashes.Add(hash))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
