namespace LeetCode.Problems._0426_Convert_Binary_Search_Tree_to_Sorted_Doubly_Linked_List;

public class Node
{
    // ReSharper disable once InconsistentNaming
#pragma warning disable IDE0044
    public int val;
#pragma warning restore IDE0044
    // ReSharper disable once InconsistentNaming
    public Node? left;
    // ReSharper disable once InconsistentNaming
    public Node? right;

    private Node(int val = 0, Node? left = null, Node? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static Node Create(int[] values)
    {
        var queue = new Queue<Node>();
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

        Node? CreateFromIndex(int index2) => index2 >= values.Length ? null : new Node(values[index2]);
    }

    public override string ToString()
    {
        return $"{{{val}}}";
    }
}