namespace LeetCode.Problems._1059_All_Paths_from_Source_Lead_to_Destination;

/// <summary>
/// https://leetcode.com/problems/all-paths-from-source-lead-to-destination/submissions/1990672560/
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination)
    {
        var adjNodes = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            var a = edge[0];
            var b = edge[1];
            adjNodes[a].Add(b);
        }

        if (adjNodes[destination].Count != 0)
        {
            return false;
        }

        if (source == destination)
        {
            return adjNodes[source].Count == 0;
        }

        if (adjNodes[source].Count == 0)
        {
            return false;
        }

        var nodeTypes = new NodeType[n];
        var processingCounts = new int[n];

        return Dfs(source, -1);

        bool Dfs(int node, int parentNode)
        {
            var ans = node == destination;

            if (nodeTypes[node] != NodeType.Unprocessed)
            {
                return nodeTypes[node] == NodeType.Processed;
            }

            nodeTypes[node] = NodeType.Processing;
            processingCounts[node]++;

            if (adjNodes[node].Count == 0 && node != destination)
            {
                return false;
            }


            if (adjNodes[node].Any(adjNode => !Dfs(adjNode, node)))
            {
                return false;
            }

            processingCounts[node]--;

            if (processingCounts[node] == 0)
            {
                nodeTypes[node] = NodeType.Processed;
            }

            return true;
        }
    }

    private enum NodeType
    {
        Unprocessed,
        Processing,
        Processed
    }
}