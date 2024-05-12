using JetBrains.Annotations;

namespace LeetCode.Problems._1644_Lowest_Common_Ancestor_of_a_Binary_Tree_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1001346568/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    private readonly Dictionary<(int rootVal, int pVal), bool> _foundCache = new();

    public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode? p, TreeNode? q) => p == null || q == null ? null : LowestCommonAncestorNullable(root, p, q);

    private TreeNode? LowestCommonAncestorNullable(TreeNode? root, TreeNode? p, TreeNode? q)
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
            return q == null || Found(p, q) ? root : null;
        }

        var ans = LowestCommonAncestorNullable(root.left, p, q)
               ?? LowestCommonAncestorNullable(root.right, p, q);

        if (ans != null)
        {
            return ans;
        }

        if (Found(root.left, p))
        {
            return Found(root.right, q) ? root : null;
        }

        if (Found(root.right, p))
        {
            return Found(root.left, q) ? root : null;
        }

        return null;
    }

    private bool Found(TreeNode? root, TreeNode? p)
    {
        if (root == null || p == null)
        {
            return false;
        }

        var key = (root.val, p.val);

        if (_foundCache.TryGetValue(key, out var found))
        {
            return found;
        }

        found = LowestCommonAncestorNullable(root, p, null) != null;
        _foundCache[key] = found;
        return found;
    }
}
