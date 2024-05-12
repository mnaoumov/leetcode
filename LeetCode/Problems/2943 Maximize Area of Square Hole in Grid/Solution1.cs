using JetBrains.Annotations;

namespace LeetCode.Problems._2943_Maximize_Area_of_Square_Hole_in_Grid;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-118/submissions/detail/1106130477/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
    {
        var min = Math.Min(MaxSequentialCount(hBars), MaxSequentialCount(vBars));
        return (1 + min) * (1 + min);
    }

    private static int MaxSequentialCount(int[] nums)
    {
        Array.Sort(nums);

        var last = int.MinValue;
        var ans = 1;
        var count = 0;

        foreach (var num in nums)
        {
            if (num == last + 1)
            {
                count++;
                ans = Math.Max(ans, count);
            }
            else
            {
                count = 1;
            }

            last = num;
        }

        return ans;
    }
}
