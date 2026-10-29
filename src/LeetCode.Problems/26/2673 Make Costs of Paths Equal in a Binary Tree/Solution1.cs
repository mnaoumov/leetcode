namespace LeetCode.Problems._2673_Make_Costs_of_Paths_Equal_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/945835728/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinIncrements(int n, int[] cost)
    {
        return Traverse(1).increments;

        (int totalCost, int increments) Traverse(int root)
        {
            if (root > cost.Length)
            {
                return (0, 0);
            }

            var left = 2 * root;
            var right = left + 1;

            var (leftTotalCost, leftIncrements) = Traverse(left);
            var (rightTotalCost, rightIncrements) = Traverse(right);

            return (totalCost: Math.Max(leftTotalCost, rightTotalCost) * 2 + cost[root - 1],
                increments: leftIncrements + rightIncrements + Math.Abs(leftTotalCost - rightTotalCost));
        }
    }
}
