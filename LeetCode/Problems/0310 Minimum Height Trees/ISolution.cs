using JetBrains.Annotations;

namespace LeetCode.Problems._0310_Minimum_Height_Trees;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges);
}
