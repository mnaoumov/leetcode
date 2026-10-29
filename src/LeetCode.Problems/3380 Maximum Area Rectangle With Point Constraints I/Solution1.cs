namespace LeetCode.Problems._3380_Maximum_Area_Rectangle_With_Point_Constraints_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-427/submissions/detail/1473122411/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxRectangleArea(int[][] points)
    {
        var n = points.Length;
        var pointObjs = points.Select(arr => new Point(arr[0], arr[1])).OrderBy(p => p.X).ThenBy(p => p.Y).ToArray();

        var ans = -1;

        for (var aIndex = 0; aIndex < n; aIndex++)
        {
            for (var bIndex = aIndex + 1; bIndex < n; bIndex++)
            {
                for (var dIndex = bIndex + 1; dIndex < n; dIndex++)
                {
                    for (var cIndex = dIndex + 1; cIndex < n; cIndex++)
                    {
                        var vertexIndices = new HashSet<int> { aIndex, bIndex, cIndex, dIndex };

                        var a = pointObjs[aIndex];
                        var b = pointObjs[bIndex];
                        var c = pointObjs[cIndex];
                        var d = pointObjs[dIndex];

                        if (a.X != b.X || a.Y >= b.Y || b.Y != c.Y || b.X >= c.X || c.X != d.X ||
                            c.Y <= d.Y ||
                            d.Y != a.Y || d.X <= a.X)
                        {
                            continue;
                        }

                        var hasPointsInside = false;

                        for (var eIndex = 0; eIndex < n; eIndex++)
                        {
                            if (vertexIndices.Contains(eIndex))
                            {
                                continue;
                            }

                            var e = pointObjs[eIndex];

                            if (a.X > e.X || e.X > c.X || a.Y > e.Y || e.Y > b.Y)
                            {
                                continue;
                            }

                            hasPointsInside = true;
                            break;
                        }

                        if (!hasPointsInside)
                        {
                            ans = Math.Max(ans, (c.X - a.X) * (c.Y - a.Y));
                        }
                    }
                }
            }
        }

        return ans;
    }

    private record Point(int X, int Y);
}
