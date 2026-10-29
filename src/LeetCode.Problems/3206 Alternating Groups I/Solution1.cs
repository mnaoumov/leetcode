namespace LeetCode.Problems._3206_Alternating_Groups_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-134/submissions/detail/1311627645/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfAlternatingGroups(int[] colors)
    {
        var ans = 0;
        var n = colors.Length;

        for (var i = 0; i < n; i++)
        {
            var previousIndex = i > 0 ? i - 1 : n - 1;
            var nextIndex = i < n - 1 ? i + 1 : 0;

            if (colors[previousIndex] != colors[i] && colors[nextIndex] != colors[i])
            {
                ans++;
            }
        }

        return ans;
    }
}
