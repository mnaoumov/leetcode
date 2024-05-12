using JetBrains.Annotations;

namespace LeetCode.Problems._0098_Validate_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/829655650/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public bool IsValidBST(TreeNode root)
    {
        return Validate(root, null, null);
    }

    private static bool Validate(TreeNode? node, int? min, int? max) =>
        node == null
        || (min == null || min < node.val)
        && (max == null || node.val < max)
        && Validate(node.left, min, node.val)
        && Validate(node.right, node.val, max);
}
