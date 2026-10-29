namespace LeetCode.Problems._0901_Online_Stock_Span;

/// <summary>
/// https://leetcode.com/problems/online-stock-span/submissions/839784236/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IStockSpanner Create() => new StockSpanner();

    private class StockSpanner : IStockSpanner
    {
        private readonly List<int> _list = new();

        public int Next(int price)
        {
            _list.Add(price);

            for (var i = 1; i <= _list.Count; i++)
            {
                if (_list[^i] > price)
                {
                    return i - 1;
                }
            }

            return _list.Count;
        }
    }
}
