namespace LeetCode.Problems._2508_Add_Edges_to_Make_Degrees_of_All_Nodes_Even;

/// <summary>
/// https://leetcode.com/submissions/detail/864958687/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public bool IsPossible(int n, IList<IList<int>> edges)
    {
        var neighbors = Enumerable.Range(0, n + 1).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var oddNodes = Enumerable.Range(1, n).Where(node => neighbors[node].Count % 2 == 1).ToArray();

        return oddNodes.Length switch
        {
            0 => true,
            2 => CanLinkOddNodes(0, 1),
            4 => CanLinkOddNodes(0, 1) && CanLinkOddNodes(2, 3) || CanLinkOddNodes(0, 2) && CanLinkOddNodes(1, 3) ||
                 CanLinkOddNodes(0, 3) && CanLinkOddNodes(1, 2),
            _ => false
        };

        bool CanLinkOddNodes(int index1, int index2) => !neighbors[oddNodes[index1]].Contains(oddNodes[index2]);
    }
}
