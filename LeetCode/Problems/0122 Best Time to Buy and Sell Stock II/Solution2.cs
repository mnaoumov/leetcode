using JetBrains.Annotations;

namespace LeetCode.Problems._0122_Best_Time_to_Buy_and_Sell_Stock_II;

/// <summary>
/// https://leetcode.com/submissions/detail/836257355/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxProfit(int[] prices)
    {
        var profitIfHaveStock = 0;
        var profitIfDoesNotHaveStock = 0;


        for (var i = prices.Length - 1; i >= 0; i--)
        {
            var price = prices[i];
            (profitIfHaveStock, profitIfDoesNotHaveStock) =
            (
                Math.Max(profitIfHaveStock, price + profitIfDoesNotHaveStock),
                Math.Max(profitIfDoesNotHaveStock, -price + profitIfHaveStock)
            );

        }

        return profitIfDoesNotHaveStock;
    }
}
