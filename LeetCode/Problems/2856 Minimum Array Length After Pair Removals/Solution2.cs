using JetBrains.Annotations;

namespace LeetCode.Problems._2856_Minimum_Array_Length_After_Pair_Removals;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-113/submissions/detail/1050963277/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MinLengthAfterRemovals(IList<int> nums)
    {
        var n = nums.Count;
        var j = n - 1;
        var i = n - 2;
        var ans = n;

        var removedIndices = new HashSet<int>();

        while (i >= 0)
        {
            if (nums[i] < nums[j])
            {
                ans -= 2;
                removedIndices.Add(i);

                do
                {
                    j--;
                } while (removedIndices.Contains(j));
            }

            i = Math.Min(i - 1, j - 1);
        }

        return ans;
    }
}
