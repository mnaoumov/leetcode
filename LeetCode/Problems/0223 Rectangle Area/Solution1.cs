using JetBrains.Annotations;

namespace LeetCode.Problems._0223_Rectangle_Area;

/// <summary>
/// https://leetcode.com/problems/rectangle-area/submissions/844939990/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
    {
        var rectangleA = new Rectangle(ax1, ay1, ax2, ay2);
        var rectangleB = new Rectangle(bx1, by1, bx2, by2);
        return rectangleA.GetArea() + rectangleB.GetArea() - rectangleA.IntersectWith(rectangleB).GetArea();
    }

    private record Rectangle(int X1, int Y1, int X2, int Y2)
    {
        public int GetArea()
        {
            var length = X2 - X1;
            var height = Y2 - Y1;

            if (length <= 0 || height <= 0)
            {
                return 0;
            }

            return length * height;
        }

        public Rectangle IntersectWith(Rectangle other)
        {
            return new Rectangle(Math.Max(X1, other.X1), Math.Max(Y1, other.Y1), Math.Min(X2, other.X2),
                Math.Min(Y2, other.Y2));
        }
    }
}
