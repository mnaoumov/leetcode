using JetBrains.Annotations;

namespace LeetCode._1491_Average_Salary_Excluding_the_Minimum_and_Maximum_Salary;

/// <summary>
/// https://leetcode.com/submissions/detail/923917209/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double Average(int[] salary)
    {
        Array.Sort(salary);
        return salary.Skip(1).Take(salary.Length - 2).Average();
    }
}
