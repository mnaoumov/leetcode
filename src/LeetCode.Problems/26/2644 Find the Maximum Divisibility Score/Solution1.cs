namespace LeetCode.Problems._2644_Find_the_Maximum_Divisibility_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-341/submissions/detail/934450982/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDivScore(int[] nums, int[] divisors) => divisors.GroupBy(divisor => nums.Count(num => num % divisor == 0)).MaxBy(g => g.Key)!.Min();
}
