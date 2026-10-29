namespace LeetCode.Problems._3688_Bitwise_OR_of_Even_Numbers_in_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-468/problems/bitwise-or-of-even-numbers-in-an-array/submissions/1777620108/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EvenNumberBitwiseORs(int[] nums) => nums.Where(num => num % 2 == 0).Aggregate(0, (num, acc) => num | acc);
}
