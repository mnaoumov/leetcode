namespace LeetCode.Problems._3970_Shortest_Path_With_At_Most_K_Consecutive_Identical_Characters;

/// <summary>
/// https://leetcode.com/problems/shortest-path-with-at-most-k-consecutive-identical-characters/submissions/2185133212/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int ShortestPath(int n, int[][] edges, string labels, int k)
    {
        var edgeObjs = edges.Select(arr => new Edge(arr[0], arr[1], arr[2])).ToArray();

        var edgesByU = edgeObjs.GroupBy(e => e.U).ToDictionary(g => g.Key, g => g.ToArray());

        var ans = int.MaxValue;

        var queue = new Queue<(int node, int totalWeight, char lastCharacter, int lastCharacterCount)>();
        queue.Enqueue((0, 0, '\0', 0));
        var minTotalWeights = new int[n];
        Array.Fill(minTotalWeights, int.MaxValue);

        while (queue.Count > 0)
        {
            var (node, totalWeight, lastCharacter, lastCharacterCount) = queue.Dequeue();

            minTotalWeights[node] = Math.Min(minTotalWeights[node], ans);

            if (totalWeight > minTotalWeights[node])
            {
                continue;
            }

            minTotalWeights[node] = totalWeight;

            var newLastCharacter = labels[node];
            var newLastCharacterCount = newLastCharacter == lastCharacter ? lastCharacterCount + 1 : 1;

            if (newLastCharacterCount > k)
            {
                continue;
            }

            if (node == n - 1)
            {
                ans = Math.Min(ans, totalWeight);
                continue;
            }

            foreach (var edge in edgesByU.GetValueOrDefault(node, Array.Empty<Edge>()))
            {
                var nextTotalWeight = totalWeight + edge.Weight;

                if (nextTotalWeight > ans)
                {
                    continue;
                }

                queue.Enqueue((edge.V, nextTotalWeight, newLastCharacter, newLastCharacterCount));
            }
        }

        if (ans == int.MaxValue)
        {
            ans = -1;
        }

        return ans;
    }

    private record Edge(int U, int V, int Weight);
}