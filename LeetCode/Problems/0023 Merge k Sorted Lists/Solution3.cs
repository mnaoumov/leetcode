using JetBrains.Annotations;

namespace LeetCode.Problems._0023_Merge_k_Sorted_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/829010419/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public ListNode? MergeKLists(ListNode?[] lists)
    {
        var fakeBeforeResultNode = new ListNode();
        var node = fakeBeforeResultNode;

        while (true)
        {
            int? min = null;
            ListNode? dummy = null;
            ref var minList = ref dummy;

            for (var i = 0; i < lists.Length; i++)
            {
                var list = lists[i];

                if (list == null)
                {
                    continue;
                }

                if (min == null || list.val < min)
                {
                    continue;
                }

                min = list.val;
                minList = ref lists[i];
            }

            if (min == null)
            {
                return fakeBeforeResultNode.next;
            }

            node.next = new ListNode(min.Value);
            node = node.next;
            minList = minList!.next;
        }
    }
}
