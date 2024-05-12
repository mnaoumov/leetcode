using JetBrains.Annotations;

namespace LeetCode._0733_Flood_Fill;

[PublicAPI]
public interface ISolution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color);
}
