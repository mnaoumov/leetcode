using System.Numerics;

namespace LeetCode.Problems._3867_Sum_of_GCD_of_Formed_Pairs;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-178/problems/sum-of-gcd-of-formed-pairs/submissions/1948048732/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long GcdSum(int[] nums)
    {
        var n = nums.Length;
        var prefixMax = int.MinValue;
        var prefixGcd = new int[n];

        for (var i = 0; i < n; i++)
        {
            prefixMax = Math.Max(prefixMax, nums[i]);
            prefixGcd[i] = (int) BigInteger.GreatestCommonDivisor(prefixMax, nums[i]);
        }

        Array.Sort(prefixGcd);
        var ans = 0L;

        for (var i = 0; i < n / 2; i++)
        {
            ans += (int) BigInteger.GreatestCommonDivisor(prefixGcd[i], prefixGcd[n - 1 - i]);
        }

        return ans;
    }
}
