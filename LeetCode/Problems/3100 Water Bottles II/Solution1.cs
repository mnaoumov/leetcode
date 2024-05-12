using JetBrains.Annotations;

namespace LeetCode._3100_Water_Bottles_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-391/submissions/detail/1218753599/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        var ans = numBottles;
        var emptyBottlesCount = numBottles;

        while (emptyBottlesCount >= numExchange)
        {
            emptyBottlesCount = emptyBottlesCount - numExchange + 1;
            ans++;
            numExchange++;
        }

        return ans;
    }
}
