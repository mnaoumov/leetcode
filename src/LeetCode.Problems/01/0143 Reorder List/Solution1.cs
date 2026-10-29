namespace LeetCode.Problems._0143_Reorder_List;

/// <summary>
/// https://leetcode.com/problems/reorder-list/submissions/845322200/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void ReorderList(ListNode head)
    {
        var list = new List<ListNode>();

        var node = head;

        while (node != null)
        {
            list.Add(node);
            node = node.next;
        }

        var headIndex = 0;
        var tailIndex = list.Count - 1;

        var fakeRoot = new ListNode(0, head);
        node = fakeRoot;

        while (headIndex <= tailIndex)
        {
            node.next = list[headIndex];
            node = node.next;

            if (headIndex < tailIndex)
            {
                node.next = list[tailIndex];
                node = node.next;
            }

            node.next = null;
            headIndex++;
            tailIndex--;
        }
    }
}
