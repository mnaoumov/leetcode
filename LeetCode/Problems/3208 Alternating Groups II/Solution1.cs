using JetBrains.Annotations;

namespace LeetCode.Problems._3208_Alternating_Groups_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-134/submissions/detail/1311687397/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        var ans = 0;
        var n = colors.Length;

        var groupLength = 1;

        for (var i = 1; i < n + k - 1; i++)
        {
            if (colors[i % n] != colors[(i - 1) % n])
            {
                groupLength++;

                if (groupLength < k)
                {
                    continue;
                }

                ans++;
                groupLength = k - 1;
            }
            else
            {
                groupLength = 1;
            }
        }

        return ans;
    }
}
