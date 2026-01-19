namespace LeetCode.Problems._2110_Number_of_Smooth_Descent_Periods_of_a_Stock;

/// <summary>
/// https://leetcode.com/problems/number-of-smooth-descent-periods-of-a-stock/submissions/1856708824/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long GetDescentPeriods(int[] prices)
    {
        var ans = 0L;
        var n = prices.Length;
        var sequenceLength = 1;

        for (var i = 1; i < n; i++)
        {
            if (prices[i] == prices[i - 1] - 1)
            {
                sequenceLength++;
            }
            else
            {
                ans += 1L * sequenceLength * (sequenceLength + 1) / 2;
                sequenceLength = 1;
            }
        }

        ans += 1L * sequenceLength * (sequenceLength + 1) / 2;
        return ans;
    }
}
