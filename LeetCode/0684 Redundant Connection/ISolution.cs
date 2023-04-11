using JetBrains.Annotations;

namespace LeetCode._0684_Redundant_Connection;

[PublicAPI]
public interface ISolution
{
    public int[] FindRedundantConnection(int[][] edges);
}
