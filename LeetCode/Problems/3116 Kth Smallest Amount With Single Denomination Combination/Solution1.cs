using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._3116_Kth_Smallest_Amount_With_Single_Denomination_Combination;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-393/submissions/detail/1231851263/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long FindKthSmallest(int[] coins, int k)
    {
        var m = coins.Length;
        var masksCount = 1 << m;

        var gcms = new (long gcm, int bitCount)[masksCount];
        gcms[0] = (1, 0);

        for (var i = 1; i < masksCount; i++)
        {
            var topBit = (int) Math.Log2(i);
            var highestPower = (int) Math.Pow(2, topBit);
            var (gcm, bitCount) = gcms[i - highestPower];
            gcms[i] = (gcm: Gcm(gcm, coins[topBit]), bitCount: bitCount + 1);
        }

        var low = 1L;
        var high = long.MaxValue;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

            var lessNumbersCount = 0L;

            for (var i = 1; i < masksCount; i++)
            {
                var (gcm, bitCount) = gcms[i];
                lessNumbersCount += mid / gcm * (bitCount % 2 == 1 ? 1 : -1);
            }

            if (lessNumbersCount >= k)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private static long Gcm(long a, long b) => (long) (a * b / BigInteger.GreatestCommonDivisor(a, b));
}
