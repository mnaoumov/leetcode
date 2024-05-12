using JetBrains.Annotations;

namespace LeetCode.Problems._3063_Linked_List_Frequency;

/// <summary>
/// https://leetcode.com/submissions/detail/1197151274/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode FrequenciesOfElements(ListNode head)
    {
        var counts = new Dictionary<int, int>();

        for (var node = head; node != null; node = node.next)
        {
            var value = node.val;
            counts.TryAdd(value, 0);
            counts[value]++;
        }

        var ansParent = new ListNode();
        var node2 = ansParent;

        foreach (var count in counts.Values)
        {
            node2.next = new ListNode(count);
            node2 = node2.next;
        }

        return ansParent.next!;
    }
}
