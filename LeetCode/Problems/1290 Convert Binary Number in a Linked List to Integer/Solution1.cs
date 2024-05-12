using JetBrains.Annotations;

namespace LeetCode.Problems._1290_Convert_Binary_Number_in_a_Linked_List_to_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/899425894/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetDecimalValue(ListNode head)
    {
        var result = 0;

        var node = head;

        while (node != null)
        {
            result = 2 * result + node.val;
            node = node.next;
        }

        return result;
    }
}
