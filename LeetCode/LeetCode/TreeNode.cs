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

    public override bool Equals(object? obj)
    {
        if (obj is not TreeNode treeNode)
        {
            return false;
        }

        return Equals((val, left, right), (treeNode.val, treeNode.left, treeNode.right));
    }

    // ReSharper disable NonReadonlyMemberInGetHashCode
    public override int GetHashCode() => (val, left, right).GetHashCode();
    // ReSharper restore NonReadonlyMemberInGetHashCode

    public override string ToString()
    {
        var values = new List<string>();
        TraverseByLevel(this, node => values.Add(node == null ? "null" : node.val.ToString()));
        return string.Join(",", values);
    }

    private static void TraverseByLevel(TreeNode? node, Action<TreeNode?> treeAction)
    {
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            node = queue.Dequeue();
            treeAction(node);
            if (node != null)
            {
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                else if (node.right != null)
                {
                    queue.Enqueue(null);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }
    }
}