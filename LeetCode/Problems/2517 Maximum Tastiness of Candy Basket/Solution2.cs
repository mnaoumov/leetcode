using JetBrains.Annotations;

namespace LeetCode.Problems._2517_Maximum_Tastiness_of_Candy_Basket;

/// <summary>
/// https://leetcode.com/submissions/detail/866021381/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaximumTastiness(int[] price, int k)
    {
        Array.Sort(price);

        var maxTestiness = (price[^1] - price[0]) / (k - 1);
        var minTastiness = 0;

        while (minTastiness < maxTestiness)
        {
            var midTastiness = minTastiness + (maxTestiness - minTastiness >> 1);

            if (midTastiness == minTastiness)
            {
                midTastiness = minTastiness + 1;
            }

            if (CanGetMidTastiness())
            {
                minTastiness = midTastiness;
            }
            else
            {
                maxTestiness = midTastiness - 1;
            }

            continue;

            bool CanGetMidTastiness()
            {
                var lastPrice = price[0];
                var candiesTakenCount = 1;

                for (var i = 1; i < price.Length; i++)
                {
                    if (price[i] - lastPrice >= midTastiness)
                    {
                        candiesTakenCount++;
                        lastPrice = price[i];
                    }

                    if (candiesTakenCount == k)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        return minTastiness;
    }
}
