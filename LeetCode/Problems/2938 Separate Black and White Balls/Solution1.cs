using JetBrains.Annotations;

namespace LeetCode.Problems._2938_Separate_Black_and_White_Balls;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-372/submissions/detail/1101780083/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinimumSteps(string s)
    {
        const char black = '1';

        var blackCount = 0;
        var ans = 0L;

        foreach (var ball in s)
        {
            if (ball == black)
            {
                blackCount++;
            }
            else
            {
                ans += blackCount;
            }
        }

        return ans;
    }
}
