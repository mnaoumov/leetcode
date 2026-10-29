namespace LeetCode.Problems._2192_All_Ancestors_of_a_Node_in_a_Directed_Acyclic_Graph;

[PublicAPI]
public interface ISolution
{
    IList<IList<int>> GetAncestors(int n, int[][] edges);
}
