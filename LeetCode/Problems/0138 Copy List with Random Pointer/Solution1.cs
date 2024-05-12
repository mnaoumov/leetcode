using JetBrains.Annotations;

namespace LeetCode.Problems._0138_Copy_List_with_Random_Pointer;

/// <summary>
/// https://leetcode.com/problems/copy-list-with-random-pointer/submissions/840421256/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public Node CopyRandomList(Node head)
    {
        var node = head;
        var fakeCopyRoot = new Node(0);
        var copyNodeParent = fakeCopyRoot;
        var map = new Dictionary<Node, Node>();

        while (node != null)
        {
            copyNodeParent.next = new Node(node.val);
            map[node] = copyNodeParent.next;
            node = node.next;
            copyNodeParent = copyNodeParent.next;
        }

        node = head;

        while (node != null)
        {
            if (node.random != null)
            {
                map[node].random = map[node.random];
            }

            node = node.next;
        }

        return fakeCopyRoot.next!;
    }
}
