using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2789_Largest_Element_in_an_Array_after_Merge_Operations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-355/submissions/detail/1001428994/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MaxArrayValue(int[] nums)
    {
        var numsLong = nums.Select(num => (long) num).ToArray();
        var ans = numsLong[^1];

        for (var i = numsLong.Length - 2; i >= 0; i--)
        {
            if (nums[i] <= numsLong[i + 1])
            {
                numsLong[i] += numsLong[i + 1];
            }
            ans = Math.Max(numsLong[i], ans);
        }

        return ans;
    }
}
