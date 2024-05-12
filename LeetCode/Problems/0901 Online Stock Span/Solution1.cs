using JetBrains.Annotations;

namespace LeetCode._0901_Online_Stock_Span;

/// <summary>
/// https://leetcode.com/problems/online-stock-span/submissions/839781460/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IStockSpanner Create() => new StockSpanner();

    private class StockSpanner : IStockSpanner
    {
        private readonly List<int> _list = new();

        public int Next(int price)
        {
            var left = 0;
            var right = _list.Count - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (_list[mid] >= price)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            _list.Insert(left, price);

            return left + 1;
        }
    }
}
