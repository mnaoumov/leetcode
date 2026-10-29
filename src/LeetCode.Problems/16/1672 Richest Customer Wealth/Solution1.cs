namespace LeetCode.Problems._1672_Richest_Customer_Wealth;

/// <summary>
/// https://leetcode.com/problems/richest-customer-wealth/submissions/845579196/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumWealth(int[][] accounts) => accounts.Select(account => account.Sum()).Max();
}
