#pragma warning disable CS8629
#pragma warning disable CS8619
#pragma warning disable CS8604
namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/199799092/
/// </summary>
public class Codec1 : ICodec
{
    private const string NullString = "null";
    private const char Separator = ',';

    /// <summary>
    /// Encodes a tree to a single string.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public string serialize(TreeNode root)
    {
        if (root == null)
        {
            return NullString;
        }

        return string.Join(Separator.ToString(), root.val, serialize(root.left), serialize(root.right));
    }

    /// <summary>
    /// Decodes your encoded data to tree.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public TreeNode deserialize(string data)
    {
        var parts = data.Split(Separator);
        var values = parts.Select(Parse).ToArray();

        return BuildNode(values, 0).node;
    }

    private static (TreeNode node, int nextIndex) BuildNode(int?[] values, int index)
    {
        if (values[index] == null)
        {
            return (null, index + 1);
        }

        var leftNodeIndexPair = BuildNode(values, index + 1);
        var rightNodeIndexPair = BuildNode(values, leftNodeIndexPair.nextIndex);

        var node = new TreeNode(values[index].Value)
        {
            left = leftNodeIndexPair.node,
            right = rightNodeIndexPair.node
        };

        return (node, rightNodeIndexPair.nextIndex);
    }

    private static int? Parse(string str)
    {
        if (str == NullString)
        {
            return null;
        }

        return int.Parse(str);
    }
}
