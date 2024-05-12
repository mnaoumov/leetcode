using JetBrains.Annotations;

namespace LeetCode.Problems._0234_Palindrome_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/923194534/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool IsPalindrome(ListNode head) => Check(head, head).isPalindrome;

    private static (bool isPalindrome, ListNode? newFrontNode) Check(ListNode? node, ListNode? frontNode)
    {
        if (node == null)
        {
            return (true, frontNode);
        }

        var (isNextPalindrome, nextFrontNode) = Check(node.next, frontNode);

        return !isNextPalindrome
            ? (false, nextFrontNode)
            : node.val != nextFrontNode!.val
                ? (false, nextFrontNode)
                : (true, nextFrontNode.next);
    }
}
