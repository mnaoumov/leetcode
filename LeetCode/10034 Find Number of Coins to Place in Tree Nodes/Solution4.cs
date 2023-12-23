using JetBrains.Annotations;

namespace LeetCode._10034_Find_Number_of_Coins_to_Place_in_Tree_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/1126947459/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public long[] PlacedCoins(int[][] edges, int[] cost)
    {
        const int maxSubtreeCostCount = 3;
        const int minSubtreeCostCount = 2;
        var n = edges.Length + 1;
        var ans = new long[n];

        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var a = edge[0];
            var b = edge[1];
            adjNodes[a].Add(b);
            adjNodes[b].Add(a);
        }

        var nodeStack = new Stack<(int node, int parent)>();
        nodeStack.Push((0, -1));

        var minSubtreeCostNodesArr = new List<int>?[n];
        var maxSubtreeCostNodesArr = new List<int>?[n];

        while (nodeStack.Count > 0)
        {
            var (node, parent) = nodeStack.Peek();
            var childNodes = adjNodes[node].Except(new[] { parent }).ToArray();

            var canProcess = true;

            foreach (var childNode in childNodes)
            {
                if (maxSubtreeCostNodesArr[childNode] != null)
                {
                    continue;
                }

                canProcess = false;
                nodeStack.Push((childNode, node));
            }

            if (!canProcess)
            {
                continue;
            }

            nodeStack.Pop();

            var maxSubtreeCostsPq = new PriorityQueue<int, int>();
            var minSubtreeCostsPq = new PriorityQueue<int, int>();
            maxSubtreeCostsPq.Enqueue(node, cost[node]);
            minSubtreeCostsPq.Enqueue(node, -cost[node]);

            foreach (var childNode in childNodes)
            {
                var maxChildSubtreeCostNodes = maxSubtreeCostNodesArr[childNode]!;
                var minChildSubtreeCostNodes = minSubtreeCostNodesArr[childNode]!;

                foreach (var subtreeNode in maxChildSubtreeCostNodes.Union(minChildSubtreeCostNodes))
                {
                    maxSubtreeCostsPq.Enqueue(subtreeNode, cost[subtreeNode]);
                    minSubtreeCostsPq.Enqueue(subtreeNode, -cost[subtreeNode]);

                    if (maxSubtreeCostsPq.Count > maxSubtreeCostCount)
                    {
                        maxSubtreeCostsPq.Dequeue();
                    }

                    if (minSubtreeCostsPq.Count > minSubtreeCostCount)
                    {
                        minSubtreeCostsPq.Dequeue();
                    }
                }
            }

            var maxSubtreeCostNodes = new List<int>();
            var minSubtreeCostNodes = new List<int>();

            while (maxSubtreeCostsPq.Count > 0)
            {
                maxSubtreeCostNodes.Add(maxSubtreeCostsPq.Dequeue());
            }

            while (minSubtreeCostsPq.Count > 0)
            {
                minSubtreeCostNodes.Add(minSubtreeCostsPq.Dequeue());
            }

            if (maxSubtreeCostNodes.Count < maxSubtreeCostCount)
            {
                ans[node] = 1;
            }
            else
            {
                var maxProd = 1L * cost[maxSubtreeCostNodes[0]] * cost[maxSubtreeCostNodes[1]] * cost[maxSubtreeCostNodes[2]];
                var minProd = 1L * cost[minSubtreeCostNodes[0]] * cost[minSubtreeCostNodes[1]] * cost[maxSubtreeCostNodes[2]];

                ans[node] = new[] { maxProd, minProd, 0 }.Max();
            }

            maxSubtreeCostNodesArr[node] = maxSubtreeCostNodes;
            minSubtreeCostNodesArr[node] = minSubtreeCostNodes;
        }

        return ans;
    }
}
