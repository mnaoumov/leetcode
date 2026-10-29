namespace LeetCode.Problems._1740_Find_Distance_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1322464335/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindDistance(TreeNode root, int p, int q)
    {
        var pPath = GetPath(root, p)!.ToArray();
        var qPath = GetPath(root, q)!.ToArray();

        var lastCommonVal = pPath
            .Zip(qPath, (pPathNode, qPathNode) => (pPathNode, qPathNode))
            .Last(x => x.pPathNode.val == x.qPathNode.val).pPathNode.val;

        var ans = pPath.Reverse().TakeWhile(node => node.val != lastCommonVal).Count();

        var lastCommonNodeSeen = false;

        foreach (var node in qPath)
        {
            if (node.val == lastCommonVal)
            {
                lastCommonNodeSeen = true;
                continue;
            }

            if (!lastCommonNodeSeen)
            {
                continue;
            }

            ans++;
        }

        return ans;
    }

    private static IEnumerable<TreeNode>? GetPath(TreeNode? node, int value)
    {
        if (node == null)
        {
            return null;
        }

        if (node.val == value)
        {
            return new[] { node };
        }

        var leftPath = GetPath(node.left, value);
        if (leftPath != null)
        {
            return leftPath.Prepend(node);
        }

        var rightPath = GetPath(node.right, value);
        return rightPath?.Prepend(node);
    }
}
