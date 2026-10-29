using System.Numerics;

namespace LeetCode.Problems._3625_Count_Number_of_Trapezoids_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-459/problems/count-number-of-trapezoids-ii/submissions/1704281967/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountTrapezoids(int[][] points)
    {
        var pointObjs = points.Select(p => new Point(p[0], p[1])).ToArray();

        var linePoints = new Dictionary<Line, HashSet<Point>>();

        for (var i = 0; i < pointObjs.Length; i++)
        {
            for (var j = i + 1; j < pointObjs.Length; j++)
            {
                var p1 = pointObjs[i];
                var p2 = pointObjs[j];

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
                linePoints.TryAdd(line, new HashSet<Point>());
                linePoints[line].Add(p1);
                linePoints[line].Add(p2);
            }
        }

        var parallelLineGroups = linePoints.Keys.GroupBy(line => line.Direction).Select(g => g.ToArray()).ToArray();

        var ans = 0;

        foreach (var parallelLineGroup in parallelLineGroups)
        {
            for (var i = 0; i < parallelLineGroup.Length; i++)
            {
                for (var j = i + 1; j < parallelLineGroup.Length; j++)
                {
                    var line1 = parallelLineGroup[i];
                    var line2 = parallelLineGroup[j];
                    var side1Count = linePoints[line1].Count * (linePoints[line1].Count - 1) / 2;
                    var side2Count = linePoints[line2].Count * (linePoints[line2].Count - 1) / 2;
                    ans += side1Count * side2Count;
                }
            }
        }

        return ans;
    }

    private record Point(int X, int Y);

    private record Line(int A, int B, int C)
    {
        public Point Direction => new(B, -A);
    }
}
