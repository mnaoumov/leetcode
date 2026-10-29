using System.Numerics;

namespace LeetCode.Problems._0365_Water_and_Jug_Problem;

/// <summary>
/// https://leetcode.com/submissions/detail/928790877/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
    {
        var gcd = (int) BigInteger.GreatestCommonDivisor(jug1Capacity, jug2Capacity);
        return targetCapacity % gcd == 0 && targetCapacity <= jug1Capacity + jug2Capacity;
    }
}
