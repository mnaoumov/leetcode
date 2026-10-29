using System.Numerics;

namespace LeetCode.Problems._1979_Find_Greatest_Common_Divisor_of_Array;

/// <summary>
/// https://leetcode.com/problems/find-greatest-common-divisor-of-array/submissions/2071629799/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindGCD(int[] nums) => (int) BigInteger.GreatestCommonDivisor(nums.Min(), nums.Max());
}
