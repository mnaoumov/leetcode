namespace LeetCode._1578_Minimum_Time_to_Make_Rope_Colorful;

public class Solution : ISolution
{
    public int MinCost(string colors, int[] neededTime)
    {
        var lastColor = default(char);
        var result = 0;
        var lastColorNeededTimeSum = 0;
        var lastColorNeededTimeMax = 0;

        for (int i = 0; i < colors.Length + 1; i++)
        {
            var color = i < colors.Length ? colors[i] : default;
            if (color != lastColor)
            {
                result += lastColorNeededTimeSum - lastColorNeededTimeMax;
                lastColor = color;
                lastColorNeededTimeSum = 0;
                lastColorNeededTimeMax = 0;
            }

            if (i < colors.Length)
            {
                lastColorNeededTimeSum += neededTime[i];
                lastColorNeededTimeMax = Math.Max(lastColorNeededTimeMax, neededTime[i]);
            }
        }

        return result;
    }
}