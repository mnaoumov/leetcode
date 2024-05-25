using JetBrains.Annotations;

namespace LeetCode.Problems._3160_Find_the_Number_of_Distinct_Colors_Among_the_Balls;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-131/submissions/detail/1267567480/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] QueryResults(int limit, int[][] queries)
    {
        var ballColors = new Dictionary<int, int>();
        var n = queries.Length;
        var ans = new int[n];
        var colorCounts = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var query = queries[i];
            var x = query[0];
            var y = query[1];

            if (ballColors.TryGetValue(x, out var oldColor))
            {
                colorCounts[oldColor]--;

                if (colorCounts[oldColor] == 0)
                {
                    colorCounts.Remove(oldColor);
                }
            }

            // ReSharper disable once InlineTemporaryVariable
            var newColor = y;
            colorCounts.TryAdd(newColor, 0);
            colorCounts[newColor]++;
            ballColors[x] = newColor;
            ans[i] = colorCounts.Count;
        }

        return ans;
    }
}
