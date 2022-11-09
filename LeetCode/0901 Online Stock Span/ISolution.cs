using JetBrains.Annotations;

namespace LeetCode._0901_Online_Stock_Span;

[PublicAPI]
public interface ISolution
{
    public IStockSpanner Create();
}