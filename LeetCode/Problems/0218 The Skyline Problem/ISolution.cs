using JetBrains.Annotations;

namespace LeetCode.Problems._0218_The_Skyline_Problem;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> GetSkyline(int[][] buildings);
}
