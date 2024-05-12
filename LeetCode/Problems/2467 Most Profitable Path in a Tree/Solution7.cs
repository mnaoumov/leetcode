using JetBrains.Annotations;

namespace LeetCode.Problems._2467_Most_Profitable_Path_in_a_Tree;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var nodes = BuildNodes();

        var maxProfit = Get(nodes[0], nodes[bob]);
        return maxProfit;

        int Get(Node aliceNode, Node? bobNode)
        {
            aliceNode.Visited = true;

            var cost = aliceNode.Amount;

            if (aliceNode == bobNode)
            {
                cost /= 2;
            }

            if (bobNode != null)
            {
                bobNode.Amount = 0;
            }

            var maxChildrenResult = aliceNode.Neighbors.Where(n => !n.Visited)
                .Select(aliceNextNode => Get(aliceNextNode, bobNode?.Parent))
                .DefaultIfEmpty(0)
                .Max();

            if (bobNode != null)
            {
                bobNode.Amount = amount[bobNode.Label];
            }

            var result = cost + maxChildrenResult;
            return result;
        }

        Node[] BuildNodes()
        {
            var nodes2 = new Node[amount.Length];

            for (var i = 0; i < nodes2.Length; i++)
            {
                nodes2[i] = new Node
                {
                    Label = i,
                    Amount = amount[i]
                };
            }

            foreach (var edge in edges)
            {
                var node0 = nodes2[edge[0]];
                var node1 = nodes2[edge[1]];
                node0.Neighbors.Add(node1);
                node1.Neighbors.Add(node0);
            }

            var startNode = nodes2[0];

            SetParent(startNode, null);

            return nodes2;

            void SetParent(Node node, Node? parent)
            {
                node.Parent = parent;

                foreach (var childNode in node.Neighbors.Where(childNode => childNode.Parent == null && childNode != nodes2[0]))
                {
                    SetParent(childNode, node);
                }
            }
        }
    }

    private class Node
    {
        public int Label { get; init; }
        public int Amount { get; set; }
        public List<Node> Neighbors { get; } = new();
        public bool Visited { get; set; }
        public Node? Parent { get; set; }

        public override string ToString() => $"{Label}";
    }
}
