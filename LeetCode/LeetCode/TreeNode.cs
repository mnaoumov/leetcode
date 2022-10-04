namespace LeetCode;

public class TreeNode
{
    // ReSharper disable once InconsistentNaming
    public int val;
    // ReSharper disable once InconsistentNaming
    public TreeNode? left;
    // ReSharper disable once InconsistentNaming
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static TreeNode? Create(int?[] values)
    {
        var result = Create(values, 0);
        return result;
    }

    private static TreeNode? Create(int?[] values, int index)
    {
        if (index >= values.Length || values[index] is not { } value)
        {
            return null;
        }

        var node = new TreeNode
        {
            val = value,
            left = Create(values, 2 * index + 1),
            right = Create(values, 2 * index + 2)
        };

        return node;
    }
}