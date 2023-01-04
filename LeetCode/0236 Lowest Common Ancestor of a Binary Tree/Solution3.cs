using JetBrains.Annotations;

namespace LeetCode._0236_Lowest_Common_Ancestor_of_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/871349938/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (ReferenceEquals(p, q))
        {
            return p;
        }

        var pathP = FindPath(root, p);
        var pathQ = FindPath(root, q);

        return pathP
            .Zip(pathQ,
                (pathPNode, pathQNode) => (pathNode: pathPNode, isCommonPathNode: ReferenceEquals(pathPNode, pathQNode)))
            .Last(x => x.isCommonPathNode).pathNode;
    }

    private static IEnumerable<TreeNode> FindPath(TreeNode? root, TreeNode node)
    {
        if (root == null)
        {
            yield break;
        }

        if (ReferenceEquals(root, node))
        {
            yield return root;
            yield break;
        }

        var path = FindPath(root.left, node).Concat(FindPath(root.right, node)).ToArray();

        if (!path.Any())
        {
            yield break;
        }

        yield return root;

        foreach (var pathNode in path)
        {
            yield return pathNode;
        }
    }
}