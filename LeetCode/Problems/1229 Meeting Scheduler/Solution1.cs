using JetBrains.Annotations;

namespace LeetCode.Problems._1229_Meeting_Scheduler;

/// <summary>
/// https://leetcode.com/submissions/detail/944079949/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
    {
        slots1 = slots1.OrderBy(i => i[0]).ToArray();
        slots2 = slots2.OrderBy(i => i[0]).ToArray();

        var index1 = 0;
        var index2 = 0;

        while (index1 < slots1.Length && index2 < slots2.Length)
        {
            var interval1 = slots1[index1];
            var interval2 = slots2[index2];

            var start = Math.Max(interval1[0], interval2[0]);
            var end = Math.Min(interval1[1], interval2[1]);
            var length = end - start;

            if (length >= duration)
            {
                return new[] { start, start + duration };
            }

            if (interval1[1] < interval2[1])
            {
                index1++;
            }
            else
            {
                index2++;
            }
        }

        return Array.Empty<int>();
    }
}
