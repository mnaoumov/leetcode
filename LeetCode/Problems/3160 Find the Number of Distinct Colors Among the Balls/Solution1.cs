using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3160_Find_the_Number_of_Distinct_Colors_Among_the_Balls;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-131/submissions/detail/1267560819/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] QueryResults(int limit, int[][] queries)
    {
        const int noColor = 0;
        var ballColors = new int[limit + 1];
        var n = queries.Length;
        var ans = new int[n];
        var colorCounts = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var query = queries[i];
            var x = query[0];
            var y = query[1];
            var oldColor = ballColors[x];
            // ReSharper disable once InlineTemporaryVariable
            var newColor = y;
            ballColors[x] = newColor;

            if (oldColor != noColor)
            {
                colorCounts[oldColor]--;

                if (colorCounts[oldColor] == 0)
                {
                    colorCounts.Remove(oldColor);
                }
            }

            colorCounts.TryAdd(newColor, 0);
            colorCounts[newColor]++;

            ans[i] = colorCounts.Count;
        }

        return ans;
    }
}
