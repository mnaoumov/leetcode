using JetBrains.Annotations;

namespace LeetCode._0836_Rectangle_Overlap;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        var tuple1 = ToTuple(rec1);
        var tuple2 = ToTuple(rec2);
        return Intersects((tuple1.x1, tuple1.x2), (tuple2.x1, tuple2.x2)) &&
               Intersects((tuple1.y1, tuple1.y2), (tuple2.y1, tuple2.y2));

    }

    private static bool Intersects((int a, int b) range1, (int a, int b) range2) => range1.a <= range2.a && range2.a < range1.b || range2.a <= range1.a && range1.a < range2.b;
    private static (int x1, int y1, int x2, int y2) ToTuple(IReadOnlyList<int> rectangle) => (rectangle[0], rectangle[1], rectangle[2], rectangle[3]);
}
