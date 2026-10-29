namespace LeetCode.Problems._2097_Valid_Arrangement_of_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/1466730745/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] ValidArrangement(int[][] pairs)
    {
        var inDegrees = new Dictionary<int, int>();
        var outDegrees = new Dictionary<int, int>();
        var adjNodes = new Dictionary<int, Stack<int>>();

        foreach (var pair in pairs)
        {
            var start = pair[0];
            var end = pair[1];

            outDegrees.TryAdd(start, 0);
            outDegrees.TryAdd(end, 0);
            inDegrees.TryAdd(start, 0);
            inDegrees.TryAdd(end, 0);
            adjNodes.TryAdd(start, new Stack<int>());
            adjNodes.TryAdd(end, new Stack<int>());
            outDegrees[start]++;
            inDegrees[end]++;
            adjNodes[start].Push(end);
        }

        var startNode =
            outDegrees.Keys.FirstOrDefault(node => outDegrees[node] == inDegrees[node] + 1,
                outDegrees.Keys.First());

        var path = new List<int>();

        Dfs(startNode);

        return Enumerable.Range(0, path.Count - 1).Select(index => new[] { path[index], path[index + 1] }).ToArray();

        void Dfs(int node)
        {
            while (adjNodes[node].Count > 0)
            {
                var adjNode = adjNodes[node].Pop();
                Dfs(adjNode);
            }

            path.Insert(0, node);
        }
    }
}
