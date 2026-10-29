namespace LeetCode.Problems._1059_All_Paths_from_Source_Lead_to_Destination;

/// <summary>
/// https://leetcode.com/problems/all-paths-from-source-lead-to-destination/submissions/1990634204/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination)
    {
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var a = edge[0];
            var b = edge[1];
            adjNodes[a].Add(b);
        }

        return adjNodes[0].Count > 0 && adjNodes[0].All(sourceNode => HasPath(sourceNode, new HashSet<int> { 0 }));

        bool HasPath(int sourceNode, HashSet<int> visitedNodes)
        {
            if (sourceNode == n - 1)
            {
                return true;
            }

            if (!visitedNodes.Add(sourceNode))
            {
                return false;
            }

            return adjNodes[sourceNode].Any(node => HasPath(node, visitedNodes));
        }
    }
}
