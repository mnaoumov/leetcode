using JetBrains.Annotations;

namespace LeetCode._0104_Maximum_Depth_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/830087995/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDepth(TreeNode root)
    {
        return MaxDepth(root, 0);
    }

    private static int MaxDepth(TreeNode? node, int depth) => node == null ? depth : Math.Max(MaxDepth(node.left, depth + 1), MaxDepth(node.right, depth + 1));
}
