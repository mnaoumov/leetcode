using JetBrains.Annotations;

namespace LeetCode.Problems._1644_Lowest_Common_Ancestor_of_a_Binary_Tree_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1001250388/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode? p, TreeNode? q) =>
        p == null || q == null ? null : LowestCommonAncestorNullable(root, p, q);

    private static TreeNode? LowestCommonAncestorNullable(TreeNode? root, TreeNode? p, TreeNode? q)
    {
        if (root == null || p == null && q == null)
        {
            return null;
        }

        if (p == null || Equals(root, q))
        {
            (p, q) = (q, p);
        }

        if (Equals(root, p))
        {
            return q == null || Found(p, q, null) ? root : null;
        }

        return
            LowestCommonAncestorNullable(root.left, p, q)
            ?? LowestCommonAncestorNullable(root.right, p, q)
            ?? (
                Found(root.left, p, null) && Found(root.right, q, null)
                || Found(root.right, p, null) && Found(root.left, q, null)
                    ? root
                    : null);
    }

    private static bool Found(TreeNode? root, TreeNode? p, TreeNode? q) => LowestCommonAncestorNullable(root, p, q) != null;
}
