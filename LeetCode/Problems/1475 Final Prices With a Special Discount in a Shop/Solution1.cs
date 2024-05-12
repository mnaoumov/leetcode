using JetBrains.Annotations;

namespace LeetCode.Problems._1475_Final_Prices_With_a_Special_Discount_in_a_Shop;

/// <summary>
/// https://leetcode.com/submissions/detail/903214037/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FinalPrices(int[] prices)
    {
        var n = prices.Length;

        var result = new int[n];

        var stack = new Stack<int>();

        for (var i = n - 1; i >= 0; i--)
        {
            var price = prices[i];

            while (stack.TryPeek(out var minPrice) && price < minPrice)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                result[i] = price;
            }
            else
            {
                result[i] = price - stack.Peek();
            }

            stack.Push(price);
        }

        return result;
    }
}
