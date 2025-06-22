namespace LeetCode.Problems._0663_Equal_Tree_Partition;

/// <summary>
/// https://leetcode.com/problems/equal-tree-partition/submissions/1664496747/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CheckEqualTree(TreeNode root)
    {
        var sums = new HashSet<int>();
        var rootSum = Sum(root);
        if (rootSum % 2 != 0)
        {
            return false;
        }

        var halfSum = rootSum / 2;
        return sums.Contains(halfSum);

        int Sum(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            var sum = node.val + Sum(node.left) + Sum(node.right);
            sums.Add(sum);
            return sum;
        }
    }
}
