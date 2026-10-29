using System.Numerics;

namespace LeetCode.Problems._3574_Maximize_Subarray_GCD_Score;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-158/problems/maximize-subarray-gcd-score/submissions/1656763098/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxGCDScore(int[] nums, int k)
    {
        var n = nums.Length;
        var powersOfTwo = new int[n];

        for (var i = 0; i < n; i++)
        {
            while (nums[i] % 2 == 0)
            {
                powersOfTwo[i]++;
                nums[i] /= 2;
            }
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            var gcd = nums[i];
            var minPowerOfTwo = powersOfTwo[i];
            var minPowerOfTwoCount = 0;

            for (var j = i; j < n; j++)
            {
                gcd = (int) BigInteger.GreatestCommonDivisor(gcd, nums[j]);
                if (powersOfTwo[j] < minPowerOfTwo)
                {
                    minPowerOfTwo = powersOfTwo[j];
                    minPowerOfTwoCount = 1;
                }
                else if (powersOfTwo[j] == minPowerOfTwo)
                {
                    minPowerOfTwoCount++;
                }

                var resultPowerOfTwo = minPowerOfTwoCount <= k ? minPowerOfTwo + 1 : minPowerOfTwo;
                var score = 1L * (j - i + 1) * gcd * (1L << resultPowerOfTwo);
                ans = Math.Max(ans, score);
            }
        }

        return ans;
    }
}
