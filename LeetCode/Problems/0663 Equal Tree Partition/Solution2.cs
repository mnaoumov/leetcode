namespace LeetCode.Problems._0663_Equal_Tree_Partition;

/// <summary>
/// https://leetcode.com/problems/equal-tree-partition/submissions/1664504678/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool CheckEqualTree(TreeNode root)
    {
        var sums = new HashSet<int>();
        var rootSum = Sum(root, false);
        if (rootSum % 2 != 0)
        {
            return false;
        }

        var halfSum = rootSum / 2;
        return sums.Contains(halfSum);

        int Sum(TreeNode? node, bool canSplit)
        {
            if (node == null)
            {
                return 0;
            }

            var sum = node.val + Sum(node.left, true) + Sum(node.right, true);

            if (canSplit)
            {
                sums.Add(sum);
            }

            return sum;
        }
    }
}
