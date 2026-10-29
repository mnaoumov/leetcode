using System.Numerics;

namespace LeetCode.Problems._3625_Count_Number_of_Trapezoids_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-459/problems/count-number-of-trapezoids-ii/submissions/1704312310/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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

                var line = GetLine(p2, p1);
                linePoints.TryAdd(line, new HashSet<Point>());
                linePoints[line].Add(p1);
                linePoints[line].Add(p2);
            }
        }

        var parallelLineGroups = linePoints.Keys.GroupBy(line => line.Direction).Select(g => g.ToArray()).ToArray();


        var handledDirections = new HashSet<Point>();

        var ans = 0;

        foreach (var parallelLineGroup in parallelLineGroups)
        {
            if (parallelLineGroup.Length < 2)
            {
                continue;
            }

            handledDirections.Add(parallelLineGroup[0].Direction);

            for (var i = 0; i < parallelLineGroup.Length; i++)
            {
                for (var j = i + 1; j < parallelLineGroup.Length; j++)
                {
                    var line1 = parallelLineGroup[i];
                    var line2 = parallelLineGroup[j];

                    var linePoints1 = linePoints[line1].ToArray();
                    var linePoints2 = linePoints[line2].ToArray();

                    for (var k = 0; k < linePoints1.Length; k++)
                    {
                        for (var l = k + 1; l < linePoints1.Length; l++)
                        {
                            for (var m = 0; m < linePoints2.Length; m++)
                            {
                                for (var n = m + 1; n < linePoints2.Length; n++)
                                {
                                    var line3 = GetLine(linePoints1[k], linePoints2[m]);
                                    var line4 = GetLine(linePoints1[k], linePoints2[n]);

                                    if (handledDirections.Contains(line3.Direction) || handledDirections.Contains(line4.Direction))
                                    {
                                        continue;
                                    }

                                    ans++;
                                }
                            }

                        }
                    }
                }
            }
        }

        return ans;
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
        public Point Direction => new(B, -A);
    }
}
