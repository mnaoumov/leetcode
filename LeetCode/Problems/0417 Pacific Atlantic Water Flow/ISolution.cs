using JetBrains.Annotations;

namespace LeetCode._0417_Pacific_Atlantic_Water_Flow;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights);
}
