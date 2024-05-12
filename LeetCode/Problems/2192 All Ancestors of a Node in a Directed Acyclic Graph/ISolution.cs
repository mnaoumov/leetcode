using JetBrains.Annotations;

namespace LeetCode._2192_All_Ancestors_of_a_Node_in_a_Directed_Acyclic_Graph;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges);
}
