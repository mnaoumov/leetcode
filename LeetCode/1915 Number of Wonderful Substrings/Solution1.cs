using JetBrains.Annotations;

namespace LeetCode._1915_Number_of_Wonderful_Substrings;

/// <summary>
/// https://leetcode.com/submissions/detail/1246981858/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long WonderfulSubstrings(string word)
    {
        const int lettersCount = 10;

        var n = word.Length;
        var maskCounts = new Dictionary<int, int>
        {
            [0] = 1
        };

        var mask = 0;

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            var letter = word[i];
            var letterIndex = letter - 'a';
            mask ^= 1 << letterIndex;

            ans += maskCounts.GetValueOrDefault(mask);

            for (var j = 0; j < lettersCount; j++)
            {
                var otherMask = mask ^ 1 << j;
                ans += maskCounts.GetValueOrDefault(otherMask);
            }

            maskCounts.TryAdd(mask, 0);
            maskCounts[mask]++;
        }

        return ans;
    }
}
