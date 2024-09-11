using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2366_Minimum_Replacements_to_Sort_the_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1035520149/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinimumReplacement(int[] nums)
    {
        var ans = 0L;
        var last = int.MaxValue;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var num = nums[i];

            if (num > last)
            {
                ans += (num - 1) / last;
                num %= last;

                if (num == 0)
                {
                    num = last;
                }
            }

            last = num;
        }

        return ans;
    }
}
