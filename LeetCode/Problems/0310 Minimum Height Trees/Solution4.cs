namespace LeetCode.Problems._0310_Minimum_Height_Trees;

/// <summary>
/// https://leetcode.com/submissions/detail/937156245/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n <= 2)
        {
            return Enumerable.Range(0, n).ToArray();
        }

        var adjNodes = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjNodes[edge[0]].Add(edge[1]);
            adjNodes[edge[1]].Add(edge[0]);
        }

        var leaves = new Queue<int>();

        for (var i = 0; i < n; i++)
        {
            if (adjNodes[i].Count == 1)
            {
                leaves.Enqueue(i);
            }
        }

        var nodesLeft = n;

        while (nodesLeft > 2)
        {
            var count = leaves.Count;
            var nextNodes = new HashSet<int>();

            for (var i = 0; i < count; i++)
            {
                var node = leaves.Dequeue();
                var nextNode = adjNodes[node].First();
                adjNodes[nextNode].Remove(node);

                if (!nextNodes.Add(nextNode))
                {
                    continue;
                }

                leaves.Enqueue(nextNode);
            }

            nodesLeft -= count;
        }

        return leaves.ToArray();
    }
}
