namespace LeetCode.Problems._2706_Buy_Two_Chocolates;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-105/submissions/detail/958301723/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int BuyChoco(int[] prices, int money)
    {
        Array.Sort(prices);
        var ans = money - prices[0] - prices[1];
        return ans >= 0 ? ans : money;
    }
}
