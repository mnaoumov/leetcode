using JetBrains.Annotations;

namespace LeetCode._0714_Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee;

[PublicAPI]
public interface ISolution
{
    public int MaxProfit(int[] prices, int fee);
}
