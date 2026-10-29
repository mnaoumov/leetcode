using System.Collections.Immutable;

namespace LeetCode.Problems._1059_All_Paths_from_Source_Lead_to_Destination;

/// <summary>
/// https://leetcode.com/problems/all-paths-from-source-lead-to-destination/submissions/1990639344/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
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

        return adjNodes[source].Count > 0 && adjNodes[source].All(sourceNode => CheckPath(sourceNode, ImmutableHashSet<int>.Empty.Add(source)) == CheckPathResult.HasPathToTarget);

        CheckPathResult CheckPath(int sourceNode, ImmutableHashSet<int> visitedNodes)
        {
            if (visitedNodes.Contains(sourceNode))
            {
                return CheckPathResult.HasLoop;
            }

            visitedNodes = visitedNodes.Add(sourceNode);

            var hasPathToTarget = sourceNode == destination;

            foreach (var checkPathResult in adjNodes[sourceNode].Select(node => CheckPath(node, visitedNodes)))
            {
                switch (checkPathResult)
                {
                    case CheckPathResult.HasPathToTarget:
                        hasPathToTarget = true;
                        break;
                    case CheckPathResult.HasLoop:
                        return CheckPathResult.HasLoop;
                    case CheckPathResult.DoesNotHaveLoop:
                        break;
                    default:
                        throw new InvalidOperationException($"Unsupported CheckPathResult {checkPathResult}");
                }
            }

            return hasPathToTarget ? CheckPathResult.HasPathToTarget : CheckPathResult.DoesNotHaveLoop;
        }
    }

    private enum CheckPathResult
    {
        HasPathToTarget,
        HasLoop,
        DoesNotHaveLoop
    }
}
