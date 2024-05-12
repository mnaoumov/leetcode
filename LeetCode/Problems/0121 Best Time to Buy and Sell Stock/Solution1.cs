using JetBrains.Annotations;

namespace LeetCode.Problems._0121_Best_Time_to_Buy_and_Sell_Stock;

/// <summary>
/// https://leetcode.com/submissions/detail/836248252/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProfit(int[] prices)
    {
        var minPrice = int.MaxValue;
        var maxPrice = int.MinValue;
        var result = 0;

        foreach (var price in prices)
        {
            if (price < minPrice)
            {
                minPrice = price;
                maxPrice = int.MinValue;
            }
            else if (price > maxPrice)
            {
                maxPrice = price;
                result = Math.Max(result, maxPrice - minPrice);
            }
        }

        return result;
    }
}
