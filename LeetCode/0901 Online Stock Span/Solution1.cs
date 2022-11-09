using JetBrains.Annotations;

namespace LeetCode._0901_Online_Stock_Span;

/// <summary>
/// https://leetcode.com/problems/online-stock-span/submissions/839781460/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IStockSpanner Create()
    {
        return new StockSpanner1();
    }
}