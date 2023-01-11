namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/875920462/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Codec2 : ICodec
{
    public string serialize(TreeNode? root) => SerializeWithDepth(root, 0);

    public TreeNode? deserialize(string data) => DeserializeWithDepth(data, 0);

    private static string DepthSeparator(int depth) => $"|{depth}|";

    private static string SerializeWithDepth(TreeNode? node, int depth) => node == null
        ? "null"
        : $"{node.val}{DepthSeparator(depth)}{SerializeWithDepth(node.left, depth + 1)}{DepthSeparator(depth)}{SerializeWithDepth(node.right, depth + 1)}";

    private static TreeNode? DeserializeWithDepth(string nodeStr, int depth)
    {
        if (nodeStr == "null")
        {
            return null;
        }

        var parts = nodeStr.Split(DepthSeparator(depth));

        return new TreeNode
        {
            val = Convert.ToInt32(parts[0]),
            left = DeserializeWithDepth(parts[1], depth + 1),
            right = DeserializeWithDepth(parts[2], depth + 1)
        };
    }
}