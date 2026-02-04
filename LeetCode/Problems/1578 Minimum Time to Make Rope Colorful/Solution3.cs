namespace LeetCode.Problems._1578_Minimum_Time_to_Make_Rope_Colorful;

/// <summary>
/// https://leetcode.com/submissions/detail/829080151/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinCost(string colors, int[] neededTime)
    {
        var lastColor = '\0';
        var result = 0;
        var lastColorNeededTimeSum = 0;
        var lastColorNeededTimeMax = 0;

        for (var i = 0; i < colors.Length + 1; i++)
        {
            var color = i < colors.Length ? colors[i] : '\0';
            if (color != lastColor)
            {
                result += lastColorNeededTimeSum - lastColorNeededTimeMax;
                lastColor = color;
                lastColorNeededTimeSum = 0;
                lastColorNeededTimeMax = 0;
            }

            if (i >= colors.Length)
            {
                continue;
            }

            lastColorNeededTimeSum += neededTime[i];
            lastColorNeededTimeMax = Math.Max(lastColorNeededTimeMax, neededTime[i]);
        }

        return result;
    }
}
