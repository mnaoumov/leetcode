using JetBrains.Annotations;

namespace LeetCode.Problems._2555_Maximize_Win_From_Two_Segments;

/// <summary>
/// https://leetcode.com/submissions/detail/891638102/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaximizeWin(int[] prizePositions, int k)
    {
        var counts = prizePositions.GroupBy(x => x).Select(g => (position: g.Key, count: g.Count())).ToArray();
        var n = counts.Length;

        var result = 0;
        var start1 = 0;
        var start2 = 0;
        var end2 = 0;
        var count1 = 0;
        var count2 = 0;
        var maxCount1 = 0;

        while (start2 < n)
        {
            while (end2 < n && counts[end2].position - counts[start2].position <= k)
            {
                count2 += counts[end2].count;
                end2++;
            }

            if (start2 > 0)
            {
                var end1 = start2 - 1;
                count1 += counts[end1].count;
                count2 -= counts[end1].count;

                while (counts[end1].position - counts[start1].position > k)
                {
                    count1 -= counts[start1].count;
                    start1++;
                }

                maxCount1 = Math.Max(maxCount1, count1);
            }

            result = Math.Max(result, maxCount1 + count2);
            start2++;
        }

        return result;
    }
}
