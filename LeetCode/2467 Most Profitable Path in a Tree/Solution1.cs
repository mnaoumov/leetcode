using JetBrains.Annotations;

namespace LeetCode._2467_Most_Profitable_Path_in_a_Tree;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-91/submissions/detail/842023664/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var childrenMap = new Dictionary<int, List<int>>();
        var parentsMap = new Dictionary<int, int>();

        foreach (var edge in edges)
        {
            var parent = edge.Min();
            var child = edge.Max();

            if (!childrenMap.ContainsKey(parent))
            {
                childrenMap[parent] = new List<int>();
            }

            childrenMap[parent].Add(child);
            parentsMap[child] = parent;
        }

        var queue = new Queue<(int aliceNode, int aliceProfit, int bobNode)>();
        queue.Enqueue((0, 0, bob));
        var result = int.MinValue;

        while (queue.Count > 0)
        {
            var (aliceNode, aliceProfit, bobNode) = queue.Dequeue();

            var aliceNextProfit = aliceProfit + (aliceNode == bobNode ? amount[aliceNode] / 2 : amount[aliceNode]);
            amount[aliceNode] = 0;
            amount[bobNode] = 0;

            if (!childrenMap.ContainsKey(aliceNode))
            {
                result = Math.Max(result, aliceNextProfit);
                continue;
            }

            var bobNextNode = bobNode == 0 ? 0 : parentsMap[bobNode];

            foreach (var aliceNextNode in childrenMap[aliceNode])
            {
                queue.Enqueue((aliceNextNode, aliceNextProfit, bobNextNode));
            }
        }

        return result;
    }
}
