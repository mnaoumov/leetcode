using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0503_Next_Greater_Element_II;

/// <summary>
/// https://leetcode.com/submissions/detail/935553485/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] NextGreaterElements(int[] nums)
    {
        var n = nums.Length;
        var ans = new int[n];
        var numIndicesMap = Enumerable.Range(0, n).GroupBy(i => nums[i])
            .ToDictionary(g => g.Key, g => g.ToArray());
        var uniqueNums = numIndicesMap.Keys.OrderBy(num => num).ToArray();

        for (var i = 0; i < uniqueNums.Length; i++)
        {
            var num = uniqueNums[i];
            var nextNum = i < uniqueNums.Length - 1 ? uniqueNums[i + 1] : -1;

            foreach (var index in numIndicesMap[num])
            {
                ans[index] = nextNum;
            }
        }

        return ans;
    }
}
