using JetBrains.Annotations;

namespace LeetCode._2508_Add_Edges_to_Make_Degrees_of_All_Nodes_Even;

[PublicAPI]
public interface ISolution
{
    public bool IsPossible(int n, IList<IList<int>> edges);
}
