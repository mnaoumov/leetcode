using JetBrains.Annotations;

namespace LeetCode._0234_Palindrome_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/899251624/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsPalindrome(ListNode head)
    {
        var node = head;
        ListNode? reverseNode = null;
        var length = 0;

        while (node != null)
        {
            length++;
            var clone = new ListNode(node.val)
            {
                next = reverseNode
            };
            node = node.next;
            reverseNode = clone;
        }

        node = head;

        for (var i = 0; i < length / 2; i++)
        {
            if (node!.val != reverseNode!.val)
            {
                return false;
            }

            node = node.next;
            reverseNode = reverseNode.next;
        }

        return true;
    }
}
