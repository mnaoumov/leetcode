using JetBrains.Annotations;

namespace LeetCode.Problems._0901_Online_Stock_Span;

public interface IStockSpanner
{
    [UsedImplicitly]
    public int Next(int price);
}
