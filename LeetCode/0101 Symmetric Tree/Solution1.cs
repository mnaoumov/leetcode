using JetBrains.Annotations;

namespace LeetCode._0101_Symmetric_Tree;

/// <summary>
/// Recursive
/// https://leetcode.com/submissions/detail/829676103/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsSymmetric(TreeNode root)
    {
        return IsSymmetric(root.left, root.right);
    }

    private static bool IsSymmetric(TreeNode? node1, TreeNode? node2)
    {
        if (node1 == null || node2 == null)
        {
            return node1 == null && node2 == null;
        }

        return node1.val == node2.val && IsSymmetric(node1.left, node2.right) && IsSymmetric(node1.right, node2.left);
    }
}