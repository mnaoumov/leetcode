namespace LeetCode.Problems._3367_Maximize_Sum_of_Weights_after_Edge_Removals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-425/submissions/detail/1461280600/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MaximizeSumOfWeights(int[][] edges, int k)
    {
        var n = edges.Length + 1;
        var edgeCounts = new int[n];

        var ans = 0L;
        var pq = new PriorityQueue<Edge, int>();

        foreach (var edge in edges)
        {
            var edgeObj = new Edge(edge[0], edge[1], edge[2]);
            edgeCounts[edgeObj.Node1]++;
            edgeCounts[edgeObj.Node2]++;
            ans += edgeObj.Weight;
            pq.Enqueue(edgeObj, edgeObj.Weight);
        }

        while (pq.Count > 0)
        {
            var edge = pq.Dequeue();
            if (edgeCounts[edge.Node1] <= k && edgeCounts[edge.Node2] <= k)
            {
                continue;
            }

            ans -= edge.Weight;
            edgeCounts[edge.Node1]--;
            edgeCounts[edge.Node2]--;
        }

        return ans;
    }

    private record Edge(int Node1, int Node2, int Weight);
}
