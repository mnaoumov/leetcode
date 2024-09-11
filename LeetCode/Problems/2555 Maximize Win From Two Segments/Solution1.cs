using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2555_Maximize_Win_From_Two_Segments;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-97/submissions/detail/891392306/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximizeWin(int[] prizePositions, int k)
    {
        var counts = prizePositions.GroupBy(x => x).Select(g => (position: g.Key, count: g.Count())).ToArray();

        var start1 = 0;
        var result = 0;
        var n = counts.Length;
        var maxCount1 = 0;

        while (start1 < n)
        {
            var end1 = start1;
            var count1 = 0;

            while (end1 < n && counts[end1].position - counts[start1].position <= k)
            {
                count1 += counts[end1].count;
                end1++;
            }

            maxCount1 = Math.Max(maxCount1, count1);

            var start2 = end1;
            var end2 = end1;

            var count2 = 0;

            if (start2 < n)
            {
                while (end2 < n && counts[end2].position - counts[start2].position <= k)
                {
                    count2 += counts[end2].count;
                    end2++;
                }
            }

            result = Math.Max(result, maxCount1 + count2);
            start1++;
        }

        return result;
    }
}
