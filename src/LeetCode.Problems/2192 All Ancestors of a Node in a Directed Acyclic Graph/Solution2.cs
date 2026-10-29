namespace LeetCode.Problems._2192_All_Ancestors_of_a_Node_in_a_Directed_Acyclic_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/906869118/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        var result = Enumerable.Range(0, n).Select(_ => new SortedSet<int>()).ToArray();
        var nextNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray<IList<int>>();
        var indegrees = new int[n];

        foreach (var edge in edges)
        {
            nextNodes[edge[0]].Add(edge[1]);
            indegrees[edge[1]]++;
        }

        var queue = new Queue<int>();

        for (var i = 0; i < n; i++)
        {
            if (indegrees[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            foreach (var nextNode in nextNodes[node])
            {
                result[nextNode].UnionWith(result[node]);
                result[nextNode].Add(node);
                indegrees[nextNode]--;

                if (indegrees[nextNode] == 0)
                {
                    queue.Enqueue(nextNode);
                }
            }
        }

        return result.Select(set => set.ToArray()).ToArray<IList<int>>();
    }
}
