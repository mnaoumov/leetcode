using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2181_Merge_Nodes_in_Between_Zeros;

/// <summary>
/// https://leetcode.com/submissions/detail/1308834461/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode MergeNodes(ListNode head)
    {
        var ansParent = new ListNode();
        var ansNode = ansParent;
        var node = head;

        while (node.next != null)
        {
            if (node.val == 0)
            {
                ansNode.next = new ListNode();
                ansNode = ansNode.next;
                
            }
            else
            {
                ansNode.val += node.val;
            }

            node = node.next;
        }

        return ansParent.next!;
    }
}
