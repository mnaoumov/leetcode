namespace LeetCode.Problems._3536_Maximum_Product_of_Two_Digits;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-448/problems/maximum-product-of-two-digits/submissions/1624859540/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProduct(int n) => n.ToString().ToCharArray().Select(c => c - '0').OrderByDescending(x=>x).Take(2).Aggregate(1, (x, y) => x * y);
}
