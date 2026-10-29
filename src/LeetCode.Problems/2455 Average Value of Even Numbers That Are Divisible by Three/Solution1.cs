namespace LeetCode.Problems._2455_Average_Value_of_Even_Numbers_That_Are_Divisible_by_Three;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-317/submissions/detail/833041477/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AverageValue(int[] nums) => (int) nums.Where(num => num % 6 == 0).DefaultIfEmpty(0).Average();
}
