// ReSharper disable All
#pragma warning disable
#pragma warning disable
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0098_Validate_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/200144698/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, int.MinValue, int.MaxValue);
    }

    private bool IsValidBST(TreeNode root, int min, int max)
    {
        if (root == null)
        {
            return true;
        }

        return min <= root.val && root.val <= max &&
               IsValidBST(root.left, min, root.val) &&
               IsValidBST(root.right, root.val, max);
    }
}
