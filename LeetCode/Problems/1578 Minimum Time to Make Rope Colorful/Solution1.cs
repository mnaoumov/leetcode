// ReSharper disable All
#pragma warning disable

using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._1578_Minimum_Time_to_Make_Rope_Colorful;

/// <summary>
/// https://leetcode.com/submissions/detail/814106619/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(string colors, int[] neededTime)
    {
        var lastColor = colors[0];
        var lastColorStartingIndex = 0;
        var result = 0;

        for (int i = 1; i < colors.Length + 1; i++)
        {
            var color = colors.ElementAtOrDefault(i);
            if (color != lastColor)
            {
                var lastColorCount = i - lastColorStartingIndex;
                if (lastColorCount > 1)
                {
                    var neededTimeForGroup = neededTime.Skip(lastColorStartingIndex).Take(lastColorCount);
                    result += neededTimeForGroup.Sum() - neededTimeForGroup.Max();
                }

                lastColor = color;
                lastColorStartingIndex = i;
            }
        }

        return result;
    }
}
