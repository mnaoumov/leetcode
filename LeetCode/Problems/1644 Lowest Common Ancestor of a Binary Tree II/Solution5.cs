namespace LeetCode.Problems._1644_Lowest_Common_Ancestor_of_a_Binary_Tree_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1001354574/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution5 : ISolution
{
    public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode? p, TreeNode? q)
    {
        if (p == null || q == null)
        {
            return null;
        }

        var pPath = FindPath(root, p)!;
        var qPath = FindPath(root, q)!;

        var i = 0;

        while (i < pPath.Count && i < qPath.Count && ReferenceEquals(pPath[i], qPath[i]))
        {
            i++;
        }

        return pPath[i - 1];
    }

    private static IList<TreeNode>? FindPath(TreeNode? current, TreeNode target)
    {
        if (current == null)
        {
            return null;
        }

        if (ReferenceEquals(current, target))
        {
            return new[] { current };
        }

        var leftPath = FindPath(current.left, target)?.ToList();

        if (leftPath != null)
        {
            leftPath.Insert(0, current);
            return leftPath;
        }

        var rightPath = FindPath(current.right, target)?.ToList();

        if (rightPath == null)
        {
            return null;
        }

        rightPath.Insert(0, current);
        return rightPath;

    }
}
