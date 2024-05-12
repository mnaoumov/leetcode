using JetBrains.Annotations;

namespace LeetCode.Problems._2558_Take_Gifts_From_the_Richest_Pile;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-331/submissions/detail/891688137/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long PickGifts(int[] gifts, int k)
    {
        var pq = new PriorityQueue<int, int>();

        foreach (var gift in gifts)
        {
            pq.Enqueue(gift, -gift);
        }

        for (var i = 0; i < k; i++)
        {
            var gift = pq.Dequeue();
            var leftover = (int) Math.Sqrt(gift);
            pq.Enqueue(leftover, -leftover);
        }

        return pq.UnorderedItems.Sum(x => x.Element);
    }
}
