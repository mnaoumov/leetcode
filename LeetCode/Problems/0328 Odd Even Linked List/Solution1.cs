using JetBrains.Annotations;

namespace LeetCode.Problems._0328_Odd_Even_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/855300631/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? OddEvenList(ListNode? head)
    {
        if (head == null)
        {
            return null;
        }

        var odd = head;
        var evenRoot = head.next;
        var even = evenRoot;

        while (true)
        {
            var nextOdd = even?.next;
            var nextEven = nextOdd?.next;
            odd.next = nextOdd;

            if (even != null)
            {
                even.next = nextEven;
            }

            if (nextOdd == null)
            {
                break;
            }

            odd = nextOdd;
            even = nextEven;
        }

        odd.next = evenRoot;

        return head;
    }
}
