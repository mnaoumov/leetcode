
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0122_Best_Time_to_Buy_and_Sell_Stock_II;

/// <summary>
/// https://leetcode.com/submissions/detail/193842830/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProfit(int[] prices)
    {
        int result = 0;
        bool hasStockToSell = false;

        for (int i = 0; i < prices.Length; i++)
        {
            bool priceStartsToIncrease = i + 1 < prices.Length && prices[i] < prices[i + 1];

            if (hasStockToSell ^ priceStartsToIncrease)
            {
                result += (hasStockToSell ? 1 : -1) * prices[i];
                hasStockToSell = !hasStockToSell;
            }
        }

        return result;
    }
}
