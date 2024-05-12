using JetBrains.Annotations;

namespace LeetCode._2856_Minimum_Array_Length_After_Pair_Removals;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-113/submissions/detail/1050941348/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinLengthAfterRemovals(IList<int> nums)
    {
        var i = 0;
        var n = nums.Count;
        var j = n - 1;
        var ans = n;

        while (i < j && nums[i] < nums[j])
        {
            i++;
            j--;
            ans -= 2;
        }

        return ans;
    }
}
