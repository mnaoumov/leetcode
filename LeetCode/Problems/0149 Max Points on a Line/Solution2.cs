using JetBrains.Annotations;

namespace LeetCode._0149_Max_Points_on_a_Line;

/// <summary>
/// https://leetcode.com/problems/max-points-on-a-line/submissions/847811444/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxPoints(int[][] points)
    {
        var skipSets = Enumerable.Range(1, points.Length).Select(_ => new HashSet<int>()).ToArray();
        var directionCounts = new Dictionary<(int x, int y, int startingPointIndex), HashSet<int>>();

        var result = 1;

        for (var i = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                if (skipSets[i].Contains(j))
                {
                    continue;
                }

                var (x, y) = GetDirection(points[i], points[j]);

                var key = (x, y, i);

                if (!directionCounts.ContainsKey(key))
                {
                    directionCounts[key] = new HashSet<int> { i };
                }

                foreach (var k in directionCounts[key])
                {
                    skipSets[k].Add(j);
                }

                directionCounts[key].Add(j);
                result = Math.Max(result, directionCounts[key].Count);
            }
        }

        return result;
    }

    private static (int x, int y) GetDirection(IReadOnlyList<int> point1, IReadOnlyList<int> point2)
    {
        var dx = point2[0] - point1[0];
        var dy = point2[1] - point1[1];

        if (dx == 0)
        {
            return (0, 1);
        }

        var d = Gcd(dx, dy);

        dx /= d;
        dy /= d;

        if (dx > 0)
        {
            return (dx, dy);
        }

        dx = -dx;
        dy = -dy;

        return (dx, dy);
    }

    private static int Gcd(int n, int m)
    {
        n = Math.Abs(n);
        m = Math.Abs(m);

        while (m > 0)
        {
            (n, m) = (m, n % m);
        }

        return n;
    }
}
