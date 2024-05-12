using JetBrains.Annotations;

namespace LeetCode._1648_Sell_Diminishing_Valued_Colored_Balls;

/// <summary>
/// https://leetcode.com/submissions/detail/966442019/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxProfit(int[] inventory, int orders)
    {
        const int modulo = 1_000_000_007;
        var ans = 0;
        var counts = inventory.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());
        var nums = new SortedSet<int>(counts.Keys);

        while (nums.Count > 0 && orders > 0)
        {
            var max = nums.Max;
            nums.Remove(max);

            var max2 = nums.Count == 0 ? 0 : nums.Max;
            var diff = max - max2;

            var k = counts[max];
            var z = Math.Min(orders / k, diff);

            orders -= z * k;
            ans = (int) ((ans + 1L * k * (1L * z * max - 1L * z * (z - 1) / 2)) % modulo);

            if (z < diff)
            {
                ans = (int) ((ans + 1L * orders * (max - z)) % modulo);
                orders = 0;
            }
            else if (nums.Count > 0)
            {
                counts[max2] += k;
            }
        }

        return ans;
    }
}
