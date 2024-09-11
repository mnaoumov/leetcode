using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0624_Maximum_Distance_in_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1104206029/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxDistance(IList<IList<int>> arrays)
    {
        var maxes = new PriorityQueue<int, int>();
        var mins = new PriorityQueue<int, int>();

        foreach (var array in arrays)
        {
            var min = array[0];
            var max = array[^1];
            maxes.Enqueue(max, max);
            mins.Enqueue(min, -min);

            if (maxes.Count == 3)
            {
                maxes.Dequeue();
            }

            if (mins.Count == 3)
            {
                mins.Dequeue();
            }
        }

        var max1 = maxes.Dequeue();
        var max2 = maxes.Dequeue();

        var min1 = mins.Dequeue();
        var min2 = mins.Dequeue();

        var ans = int.MinValue;

        foreach (var array in arrays)
        {
            var min = array[0];
            var max = array[^1];

            var otherMin = min == min1 ? min2 : min1;
            var otherMax = max == max1 ? max2 : max1;

            ans = Math.Max(ans, max - otherMin);
            ans = Math.Max(ans, otherMax - min);
        }

        return ans;
    }
}
