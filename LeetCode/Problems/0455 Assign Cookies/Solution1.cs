using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0455_Assign_Cookies;

/// <summary>
/// https://leetcode.com/submissions/detail/914084156/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        var kidIndex = 0;

        var result = 0;

        foreach (var cookieSize in s)
        {
            while (kidIndex < g.Length && g[kidIndex] > cookieSize)
            {
                kidIndex++;
            }

            if (kidIndex == g.Length)
            {
                break;
            }

            result++;
            kidIndex++;
        }

        return result;
    }
}
