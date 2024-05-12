namespace LeetCode.Problems._0589_N_ary_Tree_Preorder_Traversal;

public class Node
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public readonly int val;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public IList<Node>? children;

    private Node(int val)
    {
        this.val = val;
    }

    public static Node? CreateOrNull(int?[] values)
    {
        if (values.Length == 0)
        {
            return null;
        }

        var fakeRoot = new Node(0);
        var parent = fakeRoot;
        var queue = new Queue<Node>();

        foreach (var value in values)
        {
            if (value == null)
            {
                parent = queue.Dequeue();
                continue;
            }

            parent.children ??= new List<Node>();

            var node = new Node(value.Value);
            parent.children.Add(node);
            queue.Enqueue(node);
        }

        return fakeRoot.children![0];
    }
}
