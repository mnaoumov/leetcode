namespace LeetCode.Problems._0812_Largest_Triangle_Area;

/// <summary>
/// https://leetcode.com/problems/largest-triangle-area/submissions/1783748874/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public double LargestTriangleArea(int[][] points)
    {
        var n = points.Length;

        var ans = 0d;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                for (var k = j + 1; k < n; k++)
                {
                    var a = Length(points[i], points[j]);
                    var b = Length(points[j], points[k]);
                    var c = Length(points[k], points[i]);
                    var p = (a + b + c) / 2;
                    var s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                    if (!double.IsNaN(s))
                    {
                        ans = Math.Max(ans, s);
                    }
                }
            }
        }

        return ans;
    }

    private static double Length(int[] point1, int[] point2) => Math.Sqrt(Math.Pow(point1[0] - point2[0], 2) + Math.Pow(point1[1] - point2[1], 2));
}
