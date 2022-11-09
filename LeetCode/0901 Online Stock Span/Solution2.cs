using JetBrains.Annotations;

namespace LeetCode._0901_Online_Stock_Span;

/// <summary>
/// https://leetcode.com/problems/online-stock-span/submissions/839784236/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IStockSpanner Create()
    {
        return new StockSpanner2();
    }
}