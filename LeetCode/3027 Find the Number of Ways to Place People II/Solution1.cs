using JetBrains.Annotations;

namespace LeetCode._3027_Find_the_Number_of_Ways_to_Place_People_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-123/submissions/detail/1164944879/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfPairs(int[][] points)
    {
        var pointObjs = points.Select(Point.FromArray).OrderBy(p => p.X).ThenByDescending(p => p.Y).ToArray();
        var n = pointObjs.Length;

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var chisato = pointObjs[i];

            var maxTakinaY = int.MinValue;

            for (var j = i + 1; j < n; j++)
            {
                var takina = pointObjs[j];

                if (takina.Y > chisato.Y)
                {
                    continue;
                }

                if (takina.Y <= maxTakinaY)
                {
                    continue;
                }

                maxTakinaY = takina.Y;
                ans++;
            }
        }

        return ans;
    }

    private record Point(int X, int Y)
    {
        public static Point FromArray(IReadOnlyList<int> arr) => new(arr[0], arr[1]);
    }

}
