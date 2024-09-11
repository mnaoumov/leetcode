using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0236_Lowest_Common_Ancestor_of_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/871500466/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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

    private static IEnumerable<TreeNode> FindPath(TreeNode root, TreeNode node)
    {
        var queue = new Queue<(TreeNode? currentRoot, IEnumerable<TreeNode> path)>();
        queue.Enqueue((root, Array.Empty<TreeNode>()));

        while (queue.Count > 0)
        {
            var (currentRoot, path) = queue.Dequeue();

            if (currentRoot == null)
            {
                continue;
            }

            var nextPath = path.Append(currentRoot);

            if (ReferenceEquals(currentRoot, node))
            {
                return nextPath;
            }

            // ReSharper disable PossibleMultipleEnumeration
            queue.Enqueue((currentRoot.left, nextPath));
            queue.Enqueue((currentRoot.right, nextPath));
            // ReSharper restore PossibleMultipleEnumeration
        }

        throw new InvalidOperationException();
    }
}
