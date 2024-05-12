using JetBrains.Annotations;

namespace LeetCode.Problems._2316_Count_Unreachable_Pairs_of_Nodes_in_an_Undirected_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/921605593/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long CountPairs(int n, int[][] edges)
    {
        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var seen = new bool[n];

        var componentSizesSum = 0L;
        var componentSizeSquaresSum = 0L;

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            var componentSize = GetComponentSize(i);
            componentSizesSum += componentSize;
            componentSizeSquaresSum += 1L * componentSize * componentSize;
        }

        return (componentSizesSum * componentSizesSum - componentSizeSquaresSum) / 2;

        int GetComponentSize(int startingNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startingNode);
            var componentSize = 0;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (seen[node])
                {
                    continue;
                }

                seen[node] = true;

                componentSize++;

                foreach (var adjacentNode in adjacentNodes[node])
                {
                    queue.Enqueue(adjacentNode);
                }
            }

            return componentSize;
        }
    }
}
