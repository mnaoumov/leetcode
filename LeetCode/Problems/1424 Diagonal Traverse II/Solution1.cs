using JetBrains.Annotations;

namespace LeetCode.Problems._1424_Diagonal_Traverse_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1103817895/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        var maxDiagonalSum = nums.Select((t, i) => i + t.Count - 1).Max();

        var list = new List<int>();

        for (var diagonalSum = 0; diagonalSum <= maxDiagonalSum; diagonalSum++)
        {
            for (var i = Math.Min(diagonalSum, nums.Count - 1); i >= 0; i--)
            {
                var j = diagonalSum - i;

                if (nums[i].Count <= j)
                {
                    continue;
                }

                list.Add(nums[i][j]);
            }
        }

        return list.ToArray();
    }
}
