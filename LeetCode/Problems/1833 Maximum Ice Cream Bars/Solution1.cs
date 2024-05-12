using JetBrains.Annotations;

namespace LeetCode.Problems._1833_Maximum_Ice_Cream_Bars;

/// <summary>
/// https://leetcode.com/submissions/detail/872274527/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        Array.Sort(costs);

        var result = 0;

        foreach (var cost in costs)
        {
            if (cost > coins)
            {
                break;
            }

            coins -= cost;
            result++;
        }

        return result;
    }
}
