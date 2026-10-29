using System.Text;

namespace LeetCode.Problems._2096_Step_By_Step_Directions_From_a_Binary_Tree_Node_to_Another;

/// <summary>
/// https://leetcode.com/submissions/detail/1322423177/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        var startPath = GetPath(root, startValue).ToArray();
        var destPath = GetPath(root, destValue).ToArray();

        var lastCommonVal = startPath
            .Zip(destPath, (startPathNode, destPathNode) => (startPathNode, destPathNode))
            .Last(x => x.startPathNode.val == x.destPathNode.val).startPathNode.val;

        var sb = new StringBuilder();

        foreach (var node in startPath.Reverse())
        {
            if (node.val == lastCommonVal)
            {
                break;
            }

            sb.Append("U");
        }

        var lastCommonNodeSeen = false;

        for (var i = 0; i < destPath.Length; i++)
        {
            var node = destPath[i];

            if (node.val == lastCommonVal)
            {
                lastCommonNodeSeen = true;
                continue;
            }

            if (!lastCommonNodeSeen)
            {
                continue;
            }

            var prev = destPath[i - 1];
            sb.Append(prev.left?.val == node.val ? "L" : "R");
        }

        return sb.ToString();
    }

    private static IEnumerable<TreeNode> GetPath(TreeNode? node, int value)
    {
        if (node == null)
        {
            yield break;
        }

        if (node.val == value)
        {
            yield return node;
        }

        var leftPath = GetPath(node.left, value).ToArray();
        if (leftPath.Any())
        {
            yield return node;
            foreach (var treeNode in leftPath)
            {
                yield return treeNode;
            }
        }

        var rightPath = GetPath(node.right, value).ToArray();
        // ReSharper disable once InvertIf
        if (rightPath.Any())
        {
            yield return node;
            foreach (var treeNode in rightPath)
            {
                yield return treeNode;
            }
        }
    }
}
