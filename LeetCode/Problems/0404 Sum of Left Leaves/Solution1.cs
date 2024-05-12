using JetBrains.Annotations;

namespace LeetCode.Problems._0404_Sum_of_Left_Leaves;

/// <summary>
/// https://leetcode.com/submissions/detail/924487201/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfLeftLeaves(TreeNode root) => Dfs(root, false);

    private static int Dfs(TreeNode node, bool isLeftChild)
    {
        if (node.left == null && node.right == null && isLeftChild)
        {
            return node.val;
        }

        var result = 0;

        if (node.left != null)
        {
            result += Dfs(node.left, true);
        }

        if (node.right != null)
        {
            result += Dfs(node.right, false);
        }

        return result;
    }
}
