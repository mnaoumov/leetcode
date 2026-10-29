namespace LeetCode.Problems._2798_Number_of_Employees_Who_Met_the_Target;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-356/submissions/detail/1007319004/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfEmployeesWhoMetTarget(int[] hours, int target) => hours.Count(hour => hour >= target);
}
