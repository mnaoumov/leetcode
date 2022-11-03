namespace LeetCode._0117_Populating_Next_Right_Pointers_in_Each_Node_II;

public class Node
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public int val;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public Node? left;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public Node? right;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public Node? next;

    public Node() { }

    // ReSharper disable once InconsistentNaming
    public Node(int _val)
    {
        val = _val;
    }

    // ReSharper disable InconsistentNaming
    public Node(int _val, Node _left, Node _right, Node _next)
    // ReSharper restore InconsistentNaming
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }

    public static Node? Create(int?[] values)
    {
        var queue = new Queue<Node?>();
        var result = CreateFromIndex(0);
        queue.Enqueue(result);
        var index = 0;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            node.left = CreateFromIndex(index + 1);
            node.right = CreateFromIndex(index + 2);

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
            index += 2;
        }

        return result;


        Node? CreateFromIndex(int index2) =>
            index2 < values.Length && values[index2] is { } value ? new Node(value) : null;
    }

    public override string ToString() => $"[{val}]";
}