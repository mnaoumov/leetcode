namespace LeetCode.Problems._1059_All_Paths_from_Source_Lead_to_Destination;

/// <summary>
/// https://leetcode.com/problems/all-paths-from-source-lead-to-destination/submissions/1990637052/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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

        return adjNodes[source].Count > 0 && adjNodes[source].All(sourceNode => CheckPath(sourceNode, new HashSet<int> { 0 }) == CheckPathResult.HasPathToTarget);

        CheckPathResult CheckPath(int sourceNode, HashSet<int> visitedNodes)
        {
            if (sourceNode == destination)
            {
                return CheckPathResult.HasPathToTarget;
            }

            if (!visitedNodes.Add(sourceNode))
            {
                return CheckPathResult.HasLoop;
            }

            var hasPathToTarget = false;

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
