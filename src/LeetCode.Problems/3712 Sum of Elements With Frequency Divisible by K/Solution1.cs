namespace LeetCode.Problems._3712_Sum_of_Elements_With_Frequency_Divisible_by_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-471/problems/sum-of-elements-with-frequency-divisible-by-k/submissions/1798861439/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumDivisibleByK(int[] nums, int k) =>
        nums.GroupBy(num => num).Where(g => g.Count() % k == 0).SelectMany(num => num).Sum();
}
