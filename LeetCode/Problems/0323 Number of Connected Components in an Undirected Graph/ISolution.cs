using JetBrains.Annotations;

namespace LeetCode.Problems._0323_Number_of_Connected_Components_in_an_Undirected_Graph;

[PublicAPI]
public interface ISolution
{
    public int CountComponents(int n, int[][] edges);
}
