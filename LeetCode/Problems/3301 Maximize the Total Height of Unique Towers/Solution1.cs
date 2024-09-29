namespace LeetCode.Problems._3301_Maximize_the_Total_Height_of_Unique_Towers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-140/submissions/detail/1404967504/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumTotalSum(int[] maximumHeight)
    {
        var sorted = maximumHeight.OrderByDescending(x => x).ToArray();
        var ans = 0L;

        var lastHeight = int.MaxValue;

        foreach (var maxHeight in sorted)
        {
            lastHeight = Math.Min(lastHeight - 1, maxHeight);
            if (lastHeight <= 0)
            {
                return -1;
            }
            ans += lastHeight;
        }

        return ans;
    }
}
