namespace LeetCode.Problems._2095_Delete_the_Middle_Node_of_a_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/822147080/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode DeleteMiddle(ListNode head)
    {
        var fakeRoot = new ListNode(0, head);

        var beforeMiddleNode = fakeRoot;
        var doubleTraverseNode = head.next;

        while (doubleTraverseNode != null)
        {
            beforeMiddleNode = beforeMiddleNode.next!;
            doubleTraverseNode = doubleTraverseNode.next?.next;
        }

        beforeMiddleNode.next = beforeMiddleNode.next!.next;

        return fakeRoot.next!;
    }
}
