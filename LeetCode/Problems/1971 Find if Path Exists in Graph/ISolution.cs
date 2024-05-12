using JetBrains.Annotations;

namespace LeetCode.Problems._1971_Find_if_Path_Exists_in_Graph;

[PublicAPI]
public interface ISolution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination);
}
