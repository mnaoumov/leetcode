namespace LeetCode._0429_N_ary_Tree_Level_Order_Traversal;

public class Node
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public int val;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public IList<Node>? children;

    public Node() { }

    public Node(int val)
    {
        this.val = val;
    }

    public Node(int val, IList<Node> children)
    {
        this.val = val;
        this.children = children;
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