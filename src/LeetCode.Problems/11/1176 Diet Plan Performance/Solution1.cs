namespace LeetCode.Problems._1176_Diet_Plan_Performance;

/// <summary>
/// https://leetcode.com/problems/diet-plan-performance/submissions/1868959436/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DietPlanPerformance(int[] calories, int k, int lower, int upper)
    {
        var totalCalories = calories.Take(k).Sum();
        var ans = Point(totalCalories);

        for (var i = k; i < calories.Length; i++)
        {
            totalCalories += calories[i] - calories[i - k];
            ans += Point(totalCalories);
        }

        return ans;

        int Point(int totalCalories2)
        {
            if (totalCalories2 < lower)
            {
                return -1;
            }

            if (totalCalories2 > upper)
            {
                return 1;
            }

            return 0;
        }
    }
}
