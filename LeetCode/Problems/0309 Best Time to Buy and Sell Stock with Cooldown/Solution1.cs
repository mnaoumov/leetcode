
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0309_Best_Time_to_Buy_and_Sell_Stock_with_Cooldown;

/// <summary>
/// https://leetcode.com/submissions/detail/196716285/
/// https://leetcode.com/submissions/detail/834063404/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProfit(int[] prices)
    {
        int maxProfitAfterBuying = Int32.MinValue;
        int maxProfitAfterSelling = 0;
        int maxProfitAfterSellingTwoDaysAgo = 0;
        foreach (var price in prices)
        {
            int maxProfitAfterSellingOneDayAgo = maxProfitAfterSelling;
            int maxProfitAfterBuyingOneDayAgo = maxProfitAfterBuying;
            maxProfitAfterBuying =
                Math.Max(maxProfitAfterBuyingOneDayAgo, maxProfitAfterSellingTwoDaysAgo - price);
            maxProfitAfterSelling = Math.Max(maxProfitAfterSellingOneDayAgo, maxProfitAfterBuying + price);
            maxProfitAfterSellingTwoDaysAgo = maxProfitAfterSellingOneDayAgo;
        }

        return maxProfitAfterSelling;
    }
}
