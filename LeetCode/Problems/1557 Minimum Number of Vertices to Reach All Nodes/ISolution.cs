using JetBrains.Annotations;

namespace LeetCode.Problems._1557_Minimum_Number_of_Vertices_to_Reach_All_Nodes;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges);
}
