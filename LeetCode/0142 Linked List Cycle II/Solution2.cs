// ReSharper disable All
#pragma warning disable
using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0142_Linked_List_Cycle_II;

/// <summary>
/// https://leetcode.com/submissions/detail/195967696/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        var slowNodeCrawler = head;
        var fastNodeCrawler = head.next;

        while (fastNodeCrawler != null && fastNodeCrawler.next != null && fastNodeCrawler != slowNodeCrawler)
        {
            slowNodeCrawler = slowNodeCrawler.next;
            fastNodeCrawler = fastNodeCrawler.next.next;
        }

        if (fastNodeCrawler == null || fastNodeCrawler.next == null)
        {
            return null;
        }

        var cycleFinderAheadCrawler = head;

        do
        {
            slowNodeCrawler = slowNodeCrawler.next;
            fastNodeCrawler = fastNodeCrawler.next.next;
            cycleFinderAheadCrawler = cycleFinderAheadCrawler.next;
        } while (fastNodeCrawler != slowNodeCrawler);

        var cycleFinderBehindCrawler = head;

        while (cycleFinderBehindCrawler != cycleFinderAheadCrawler)
        {
            cycleFinderBehindCrawler = cycleFinderBehindCrawler.next;
            cycleFinderAheadCrawler = cycleFinderAheadCrawler.next;
        }

        return cycleFinderBehindCrawler;
    }
}
