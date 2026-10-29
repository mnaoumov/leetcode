namespace LeetCode.Problems._3513_Number_of_Unique_XOR_Triplets_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-154/problems/number-of-unique-xor-triplets-i/submissions/1604700081/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int UniqueXorTriplets(int[] nums)
    {
        var n = nums.Length;
        return n <= 2 ? n : 1 << (int) Math.Log2(n) + 1;
    }
}
