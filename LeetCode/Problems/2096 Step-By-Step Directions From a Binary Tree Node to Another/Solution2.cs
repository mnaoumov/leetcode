using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2096_Step_By_Step_Directions_From_a_Binary_Tree_Node_to_Another;

/// <summary>
/// https://leetcode.com/submissions/detail/1322460455/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        var startPath = GetPath(root, startValue)!.ToArray();
        var destPath = GetPath(root, destValue)!.ToArray();

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

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (rightPath != null)
        {
            return rightPath.Prepend(node);
        }

        return null;
    }
}
