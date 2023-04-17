using JetBrains.Annotations;

namespace LeetCode._0572_Subtree_of_Another_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/935017583/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot) => IsSubtree2(root, subRoot);

    private static bool IsSubtree2(TreeNode? root, TreeNode? subRoot)
    {
        if (root == null || subRoot == null)
        {
            return root == null && subRoot == null;
        }

        if (root.val == subRoot.val && IsSubtree2(root.left, subRoot.left) && IsSubtree2(root.right, subRoot.right))
        {
            return true;
        }

        return IsSubtree2(root.left, subRoot) || IsSubtree2(root.right, subRoot);
    }
}
