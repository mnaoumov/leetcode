namespace LeetCode.Problems._1557_Minimum_Number_of_Vertices_to_Reach_All_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/904445469/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var result = Enumerable.Range(0, n).ToHashSet();

        foreach (var edge in edges)
        {
            result.Remove(edge[1]);
        }

        return result.ToArray();
    }
}
