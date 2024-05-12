using JetBrains.Annotations;

namespace LeetCode.Problems._2250_Count_Number_of_Rectangles_Containing_Each_Point;

[PublicAPI]
public interface ISolution
{
    public int[] CountRectangles(int[][] rectangles, int[][] points);
}
