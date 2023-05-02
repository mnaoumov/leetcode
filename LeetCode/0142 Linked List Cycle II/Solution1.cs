// ReSharper disable All
#pragma warning disable
using JetBrains.Annotations;

namespace LeetCode._0142_Linked_List_Cycle_II;

/// <summary>
/// https://leetcode.com/submissions/detail/195967416/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode DetectCycle(ListNode head)
    {
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
