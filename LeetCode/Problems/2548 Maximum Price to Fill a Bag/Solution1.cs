using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2548_Maximum_Price_to_Fill_a_Bag;

/// <summary>
/// https://leetcode.com/submissions/detail/887106947/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public double MaxPrice(int[][] items, int capacity)
    {
        var result = 0d;

        foreach (var item in items.OrderByDescending(item => item[0]))
        {
            if (capacity == 0)
            {
                break;
            }

            var price = item[0];
            var weight = item[1];

            var weightAvailable = Math.Min(weight, capacity);
            capacity -= weightAvailable;
            result += 1d * weightAvailable / weight * price;
        }

        return capacity == 0 ? result : -1;
    }
}
