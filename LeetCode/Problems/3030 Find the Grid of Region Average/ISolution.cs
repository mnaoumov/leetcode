using JetBrains.Annotations;

namespace LeetCode.Problems._3030_Find_the_Grid_of_Region_Average;

[PublicAPI]
public interface ISolution
{
    public int[][] ResultGrid(int[][] image, int threshold);
}
