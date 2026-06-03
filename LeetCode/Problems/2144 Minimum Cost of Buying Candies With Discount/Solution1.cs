namespace LeetCode.Problems._2144_Minimum_Cost_of_Buying_Candies_With_Discount;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-of-buying-candies-with-discount/submissions/2018595700/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumCost(int[] cost)
    {
        return cost.OrderByDescending(x => x).Select((num, index) => index % 3 == 2 ? 0 : num).Sum();
    }
}
