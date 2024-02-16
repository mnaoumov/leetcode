using JetBrains.Annotations;

namespace LeetCode._3036_Number_of_Subarrays_That_Match_a_Pattern_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-384/submissions/detail/1171968622/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountMatchingSubarrays(int[] nums, int[] pattern)
    {
        var n = nums.Length;
        var m = pattern.Length;

        var prefixes = BuildPrefixFunction(pattern);

        var ans = 0;

        var j = 0;

        for (var i = 1; i < n; i++)
        {
            var actualSign = Math.Sign(nums[i].CompareTo(nums[i - 1]));

            while (j > 0 && actualSign != pattern[j])
            {
                j = prefixes[j - 1];
            }

            if (actualSign == pattern[j])
            {
                j++;
            }

            if (j < m)
            {
                continue;
            }

            ans++;
            j = prefixes[j - 1];
        }

        return ans;
    }

    private static int[] BuildPrefixFunction(IReadOnlyList<int> s)
    {
        var n = s.Count;
        var pi = new int[n];

        for (var i = 1; i < n; i++)
        {
            var j = pi[i - 1];
            while (j > 0 && s[i] != s[j])
            {
                j = pi[j - 1];
            }
            if (s[i] == s[j])
            {
                j++;
            }
            pi[i] = j;
        }

        return pi;
    }
}
