using JetBrains.Annotations;

namespace LeetCode._0573_Squirrel_Simulation;

[PublicAPI]
public interface ISolution
{
    public int MinDistance(int height, int width, int[] tree, int[] squirrel, int[][] nuts);
}
