using System.Globalization;

#pragma warning disable CA1051
namespace LeetCode.DataStructure;

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

    public static TreeNode? CreateOrNull(int?[] values)
    {
        if (values.Length == 0)
        {
            return null;
        }

        var queue = new Queue<TreeNode>();
        var result = CreateFromIndex(0)!;
        queue.Enqueue(result);

        var index = 0;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            node.left = CreateFromIndex(index + 1);
            node.right = CreateFromIndex(index + 2);

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }

            index += 2;
        }

        return result;

        TreeNode? CreateFromIndex(int index2)
        {
            if (index2 >= values.Length || values[index2] is not { } value)
            {
                return null;
            }

            return new TreeNode(value);
        }
    }

    public static TreeNode Create(int?[] values) => CreateOrNull(values) ?? throw new ArgumentException("Values represent an empty tree", nameof(values));

    public override bool Equals(object? obj) => obj is TreeNode treeNode && Equals((val, left, right), (treeNode.val, treeNode.left, treeNode.right));

    // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
    public override int GetHashCode() => base.GetHashCode();

    public override string ToString()
    {
        var valuesStr = GetValues(this).Select(value => value == null ? "null" : ((int)value).ToString(CultureInfo.InvariantCulture));
        return string.Join(",", valuesStr);
    }

    public static int?[] GetValues(TreeNode? treeNode)
    {
        var values = new List<int?>();
        TraverseByLevel(treeNode, node => values.Add(node?.val));
        return values.ToArray();
    }

    private static void TraverseByLevel(TreeNode? node, Action<TreeNode?> treeAction)
    {
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(node);

        var nullsCount = 0;

        while (queue.Count > 0)
        {
            node = queue.Dequeue();

            if (node == null)
            {
                nullsCount++;
                continue;
            }

            for (var i = 0; i < nullsCount; i++)
            {
                treeAction(null);
            }

            nullsCount = 0;

            treeAction(node);

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
    }

    public TreeNode? FindNode(int value)
    {
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            if (node.val == value)
            {
                return node;
            }

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        return null;
    }

    [UsedImplicitly]
    public static TreeNode? FromObject(object obj)
    {
        var values = ((object?[]) obj)
            .Select(valueObj => valueObj == null ? (int?) null : Convert.ToInt32(valueObj, CultureInfo.InvariantCulture))
            .ToArray();
        return CreateOrNull(values);
    }
}
