using System.Numerics;

namespace LeetCode.Problems._3733_Minimum_Time_to_Complete_All_Deliveries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-474/problems/minimum-time-to-complete-all-deliveries/submissions/1818272120/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinimumTime(int[] d, int[] r)
    {
        var commonRechargePeriod = 1L * r[0] * r[1] / (int) BigInteger.GreatestCommonDivisor(r[0], r[1]);
        return Math.Min(
            MinimumTime2(d[0], d[1], r[0], r[1], commonRechargePeriod),
            MinimumTime2(d[1], d[0], r[1], r[0], commonRechargePeriod)
        );
    }

    private static long MinimumTime2(long deliveryCount1, long deliveryCount2, long rechargePeriod1, long rechargePeriod2, long commonRechargePeriod)
    {
        var rechargeCount1 = GetRechargeCount(deliveryCount1, rechargePeriod1, 1);
        var droneTime1 = deliveryCount1 + rechargeCount1;

        var commonRechargeCount = rechargeCount1 / (commonRechargePeriod / rechargePeriod2);
        deliveryCount2 -= rechargeCount1 - commonRechargeCount;

        if (deliveryCount2 <= 0)
        {
            return droneTime1;
        }

        return droneTime1 + deliveryCount2 + GetRechargeCount(deliveryCount2, rechargePeriod2, droneTime1 + 1);
    }

    private static long GetRechargeCount(long deliveriesCount, long rechargePeriod, long startingTime)
    {
        var rechargeCountBefore = (startingTime - 1) / rechargePeriod;
        var rechargeCountAfter = (startingTime + deliveriesCount - 1) / rechargePeriod;
        var actualRechargeCount = rechargeCountAfter - rechargeCountBefore;

        if (actualRechargeCount == 0)
        {
            return 0;
        }

        return actualRechargeCount + GetRechargeCount(actualRechargeCount, rechargePeriod, startingTime + deliveriesCount);
    }
}
