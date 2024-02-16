using JetBrains.Annotations;

namespace LeetCode._3036_Number_of_Subarrays_That_Match_a_Pattern_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-384/submissions/detail/1171955235/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountMatchingSubarrays(int[] nums, int[] pattern)
    {
        var n = nums.Length;
        var m = pattern.Length;

        var prefixes = new int[m + 1];

        for (var j = 1; j <= m; j++)
        {
            var k = prefixes[j - 1];

            while (k > 0 && j < m && pattern[k] != pattern[j])
            {
                k = prefixes[k - 1];
            }

            if (j < m && pattern[k] == pattern[j])
            {
                k++;
            }

            prefixes[j] = k;
        }

        var ans = 0;

        var i = 0;

        while (i < n - m)
        {
            var matched = true;

            for (var j = 0; j < m; j++)
            {
                var expectedSign = pattern[j];
                var actualSign = Math.Sign(nums[i + j + 1].CompareTo(nums[i + j]));

                if (actualSign == expectedSign)
                {
                    continue;
                }

                matched = false;
                i = i + j - prefixes[j];
                break;
            }

            if (matched)
            {
                ans++;
                i = i + m - prefixes[m];
            }
        }

        return ans;
    }
}
