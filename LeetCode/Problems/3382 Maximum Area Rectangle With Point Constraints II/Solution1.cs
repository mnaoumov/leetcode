namespace LeetCode.Problems._3382_Maximum_Area_Rectangle_With_Point_Constraints_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long MaxRectangleArea(int[] xCoord, int[] yCoord)
    {
        var points = xCoord.Zip(yCoord, (x, y) => new Point(x, y)).OrderBy(p => p.X).ThenBy(p => p.Y).ToArray();
        var pointsSet = points.ToHashSet();
        var n = points.Length;

        for (var aIndex = 0; aIndex < n; aIndex++)
        {
            var a = points[aIndex];

            for (var cIndex = aIndex + 1; cIndex < n; cIndex++)
            {
                var c = points[cIndex];

                if (a.X >= c.X || a.Y >= c.Y)
                {
                    continue;
                }

                var b = new Point(a.X, c.Y);
                var d = new Point(c.X, a.Y);

                if (!pointsSet.Contains(b) || !pointsSet.Contains(d))
                {
                    continue;
                }
                
            }
        }

        return 0;
    }

    private record Point(int X, int Y);
}
