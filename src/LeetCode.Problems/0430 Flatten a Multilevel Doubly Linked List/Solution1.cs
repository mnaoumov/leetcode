namespace LeetCode.Problems._0430_Flatten_a_Multilevel_Doubly_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/946972976/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public Node? Flatten(Node? head)
    {
        var values = new List<int>();

        Extract(head);

        var root = new Node();

        var node = root;

        foreach (var value in values)
        {
            node.next = new Node { val = value };

            if (node.val != 0)
            {
                node.next.prev = node;
            }

            node = node.next;
        }

        return root.next;

        void Extract(Node? node2)
        {
            while (node2 != null)
            {
                values.Add(node2.val);
                Extract(node2.child);
                node2 = node2.next;
            }
        }
    }
}
