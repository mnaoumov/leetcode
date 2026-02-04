using System.Numerics;

namespace LeetCode.Problems._3625_Count_Number_of_Trapezoids_II;

/// <summary>
/// https://leetcode.com/problems/count-number-of-trapezoids-ii/submissions/1847190469/
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    public int CountTrapezoids(int[][] points)
    {
        var pointObjs = points.Select(p => new Point(p[0], p[1])).ToArray();

        var linePoints = new Dictionary<Line, HashSet<Point>>();
        var sumPointDirections = new Dictionary<Point, Dictionary<Point, int>>();

        for (var i = 0; i < pointObjs.Length; i++)
        {
            for (var j = i + 1; j < pointObjs.Length; j++)
            {
                var p1 = pointObjs[i];
                var p2 = pointObjs[j];

                var line = GetLine(p2, p1);
                linePoints.TryAdd(line, new HashSet<Point>());
                linePoints[line].Add(p1);
                linePoints[line].Add(p2);

                var sumPoint = new Point(p1.X + p2.X, p1.Y + p2.Y);
                sumPointDirections.TryAdd(sumPoint, new Dictionary<Point, int>());
                sumPointDirections[sumPoint].TryAdd(line.Direction, 0);
                sumPointDirections[sumPoint][line.Direction]++;
            }
        }

        var parallelLineGroups = linePoints.Keys.GroupBy(line => line.Direction).Select(g => g.ToArray()).ToArray();

        var ans = 0L;

        foreach (var parallelLineGroup in parallelLineGroups)
        {
            if (parallelLineGroup.Length < 2)
            {
                continue;
            }

            for (var i = 0; i < parallelLineGroup.Length; i++)
            {
                for (var j = i + 1; j < parallelLineGroup.Length; j++)
                {
                    var line1 = parallelLineGroup[i];
                    var line2 = parallelLineGroup[j];

                    var count1 = linePoints[line1].Count;
                    var count2 = linePoints[line2].Count;
                    ans += 1L * count1 * (count1 - 1) * count2 * (count2 - 1) / 4;
                }
            }
        }

        foreach (var directionCounts in sumPointDirections.Values)
        {
            var sum = 0L;
            var sumOfSquares = 0L;
            foreach (var count in directionCounts.Values)
            {
                sum += count;
                sumOfSquares += 1L * count * count;
            }
            ans -= (sum * sum - sumOfSquares) / 2;
        }
        return (int) ans;
    }

    private static Line GetLine(Point p2, Point p1)
    {
        var a = p2.Y - p1.Y;
        var b = p1.X - p2.X;

        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (a == 0)
        {
            b = 1;
        }

        if (a < 0)
        {
            a = -a;
            b = -b;
        }

        var gcd = (int) BigInteger.GreatestCommonDivisor(a, b);
        a /= gcd;
        b /= gcd;
        var c = -a * p1.X - b * p1.Y;

        var line = new Line(a, b, c);
        return line;
    }

    private record Point(int X, int Y);

    private record Line(int A, int B, int C)
    {
        public Point Direction => new Point(B, -A);
    }
}
