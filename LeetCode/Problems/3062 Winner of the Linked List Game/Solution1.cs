using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._3062_Winner_of_the_Linked_List_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/1192149383/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GameResult(ListNode head)
    {
        var even = head;
        var odd = head.next;

        var evenScore = 0;

        while (even != null && odd != null)
        {
            evenScore += Math.Sign(even.val.CompareTo(odd.val));

            even = odd.next;
            odd = even?.next;
        }

        return Math.Sign(evenScore) switch
        {
            -1 => "Odd",
            0 => "Tie",
            1 => "Even",
            _ => throw new InvalidOperationException()
        };
    }
}
