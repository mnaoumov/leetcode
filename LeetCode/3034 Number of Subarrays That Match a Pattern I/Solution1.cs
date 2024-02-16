using JetBrains.Annotations;

namespace LeetCode._3034_Number_of_Subarrays_That_Match_a_Pattern_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-384/submissions/detail/1171884245/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountMatchingSubarrays(int[] nums, int[] pattern)
    {
        var n = nums.Length;
        var m = pattern.Length;
        var ans = 0;

        for (var i = 0; i < n - m; i++)
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
                break;
            }

            if (matched)
            {
                ans++;
            }
        }

        return ans;
    }
}
