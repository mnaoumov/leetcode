// ReSharper disable All
#pragma warning disable
#pragma warning disable
using JetBrains.Annotations;

namespace LeetCode.Problems._0098_Validate_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/200145462/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, null, null);
    }

    private bool IsValidBST(TreeNode root, int? min, int? max)
    {
        if (root == null)
        {
            return true;
        }

        return (min == null || min < root.val) &&
               (max == null || root.val < max) &&
               IsValidBST(root.left, min, root.val) &&
               IsValidBST(root.right, root.val, max);
    }
}
