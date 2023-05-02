namespace LeetCode._0116_Populating_Next_Right_Pointers_in_Each_Node;

public class Node
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public readonly int val;

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
    private Node(int _val)
    {
        val = _val;
    }

    public static Node? Create(int[] values)
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


        Node? CreateFromIndex(int index2) => index2 >= values.Length ? null : new Node(values[index2]);
    }

    public override string ToString() => $"[{val}]";
}
