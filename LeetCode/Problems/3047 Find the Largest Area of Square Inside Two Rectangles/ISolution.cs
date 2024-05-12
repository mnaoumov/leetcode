using JetBrains.Annotations;

namespace LeetCode.Problems._3047_Find_the_Largest_Area_of_Square_Inside_Two_Rectangles;

[PublicAPI]
public interface ISolution
{
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight);
}
