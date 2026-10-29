namespace LeetCode.Problems._3652_Best_Time_to_Buy_and_Sell_Stock_using_Strategy;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-463/problems/best-time-to-buy-and-sell-stock-using-strategy/submissions/1737965567/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxProfit(int[] prices, int[] strategy, int k)
    {
        var sum = 0L;

        var n = prices.Length;

        for (var i = 0; i < n; i++)
        {
            sum += prices[i] * strategy[i];
        }

        var ans = sum;

        for (var i = 0; i < k / 2; i++)
        {
            sum -= prices[i] * strategy[i];
        }

        for (var i = k / 2; i < k; i++)
        {
            sum += prices[i] * (1 - strategy[i]);
        }

        ans = Math.Max(ans, sum);

        for (var j = 1; j <= n - k; j++)
        {
            sum += prices[j - 1] * strategy[j - 1];
            sum -= prices[j + k / 2 - 1];
            sum += prices[j + k - 1] * (1 - strategy[j + k - 1]);
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}
