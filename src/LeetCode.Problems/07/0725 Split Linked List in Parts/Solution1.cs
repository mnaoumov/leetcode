namespace LeetCode.Problems._0725_Split_Linked_List_in_Parts;

/// <summary>
/// https://leetcode.com/submissions/detail/1041719032/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode?[] SplitListToParts(ListNode? head, int k)
    {
        var n = Count(head);
        var minPartLength = n / k;
        var extraNodeCount = n % k;
        var ans = new ListNode?[k];

        var node = head;

        for (var i = 0; i < k; i++)
        {
            var fakeRoot = new ListNode();
            var partLength = i < extraNodeCount ? minPartLength + 1 : minPartLength;
            var partNode = fakeRoot;

            for (var j = 0; j < partLength; j++)
            {
                partNode.next = new ListNode(node!.val);
                partNode = partNode.next;
                node = node.next;
            }

            ans[i] = fakeRoot.next;
        }

        return ans;
    }

    private static int Count(ListNode? head)
    {
        var node = head;
        var ans = 0;

        while (node != null)
        {
            ans++;
            node = node.next;
        }

        return ans;
    }
}
