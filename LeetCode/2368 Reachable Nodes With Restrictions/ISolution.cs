using JetBrains.Annotations;

namespace LeetCode._2368_Reachable_Nodes_With_Restrictions;

[PublicAPI]
public interface ISolution
{
    public int ReachableNodes(int n, int[][] edges, int[] restricted);
}
