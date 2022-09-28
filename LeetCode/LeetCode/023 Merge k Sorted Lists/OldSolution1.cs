namespace LeetCode._023_Merge_k_Sorted_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/200241875/
/// </summary>
public class OldSolution1 : ISolution
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