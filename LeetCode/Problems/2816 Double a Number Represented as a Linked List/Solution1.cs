using JetBrains.Annotations;

namespace LeetCode._2816_Double_a_Number_Represented_as_a_Linked_List;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-358/submissions/detail/1019748802/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode DoubleIt(ListNode head)
    {
        ListNode? reverseNode = null;
        var directNode = head;

        while (directNode != null)
        {
            reverseNode = new ListNode(directNode.val, reverseNode);
            directNode = directNode.next;
        }

        ListNode? doubleNode = null;
        var carry = false;

        while (reverseNode != null || carry)
        {
            var val = (reverseNode?.val ?? 0) * 2 + (carry ? 1 : 0);
            carry = val >= 10;

            if (carry)
            {
                val -= 10;
            }

            doubleNode = new ListNode(val, doubleNode);
            reverseNode = reverseNode?.next;
        }

        return doubleNode!;
    }
}
