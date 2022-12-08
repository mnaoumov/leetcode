using JetBrains.Annotations;

namespace LeetCode._1413_Minimum_Value_to_Get_Positive_Step_by_Step_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/856233584/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinStartValue(int[] nums)
    {
        var sum = 0;
        var minSum = int.MaxValue;

        foreach (var num in nums)
        {
            sum += num;
            minSum = Math.Min(minSum, sum);
        }

        return Math.Max(1 - minSum, 1);
    }
}
