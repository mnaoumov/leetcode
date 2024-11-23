namespace LeetCode.Problems._3361_Shift_Distance_Between_Two_Strings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-144/submissions/detail/1460845130/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long ShiftDistance(string s, string t, int[] nextCost, int[] previousCost)
    {
        const int letterCount = 26;

        var ans = 0L;
        var n = s.Length;

        for (var i = 0; i < n; i++)
        {
            var sIndex = s[i] - 'a';
            var tIndex = t[i] - 'a';

            if (sIndex == tIndex)
            {
                continue;
            }

            var nextCostTotal = 0L;

            for (var j = sIndex; j != tIndex; j = (j + 1) % letterCount)
            {
                nextCostTotal += nextCost[j];
            }

            var previousCostTotal = 0L;

            for (var j = sIndex; j != tIndex; j = (j - 1 + letterCount) % letterCount)
            {
                previousCostTotal += previousCost[j];
            }

            ans += Math.Min(nextCostTotal, previousCostTotal);
        }

        return ans;
    }
}
