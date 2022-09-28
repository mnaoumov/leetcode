namespace LeetCode._023_Merge_k_Sorted_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/810850167/
/// </summary>
public class Solution : ISolution
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
                if (list != null)
                {
                    if (min == null || list.val < min)
                    {
                        min = list.val;
                        minList = ref lists[i];
                    }
                }
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

/// <summary>
/// https://leetcode.com/submissions/detail/200241875/
/// </summary>
public class OldSolution1 : ISolution
{
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode fakeRoot = new ListNode(0);
            ListNode mergedListNode = fakeRoot;

            while (true)
            {
                int min = int.MaxValue;
                int minListIndex = -1;
                var allListsEnded = true;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null)
                    {
                        allListsEnded = false;
                        if (lists[i].val <= min)
                        {
                            min = lists[i].val;
                            minListIndex = i;
                        }
                    }
                }

                if (!allListsEnded)
                {
                    mergedListNode.next = new ListNode(min);
                    mergedListNode = mergedListNode.next;
                    lists[minListIndex] = lists[minListIndex].next;
                }
                else
                {
                    break;
                }
            }

            return fakeRoot.next;
        }
    }
}