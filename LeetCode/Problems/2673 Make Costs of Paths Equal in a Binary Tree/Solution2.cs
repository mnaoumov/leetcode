using JetBrains.Annotations;

namespace LeetCode.Problems._2673_Make_Costs_of_Paths_Equal_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/946100258/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinIncrements(int n, int[] cost)
    {
        return Traverse(1).increments;

        (int leafPathCost, int increments) Traverse(int root)
        {
            if (root > cost.Length)
            {
                return (0, 0);
            }

            var left = 2 * root;
            var right = left + 1;

            var (leftLeafPathCost, leftIncrements) = Traverse(left);
            var (rightLeafPathCost, rightIncrements) = Traverse(right);

            return (leafPathCost: Math.Max(leftLeafPathCost, rightLeafPathCost) + cost[root - 1],
                increments: leftIncrements + rightIncrements + Math.Abs(leftLeafPathCost - rightLeafPathCost));
        }
    }
}
