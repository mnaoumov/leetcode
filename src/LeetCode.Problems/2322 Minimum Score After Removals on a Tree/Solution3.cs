namespace LeetCode.Problems._2322_Minimum_Score_After_Removals_on_a_Tree;

/// <summary>
/// https://leetcode.com/problems/minimum-score-after-removals-on-a-tree/submissions/1710371330/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinimumScore(int[] nums, int[][] edges)
    {
        const int noNode = -1;
        var n = nums.Length;
        var adjNodes = Enumerable.Range(0, n)
            .Select(_ => new List<int>())
            .ToArray();
        var parentNodes = new int[n];

        foreach (var edge in edges)
        {
            var a = edge[0];
            var b = edge[1];
            adjNodes[a].Add(b);
            adjNodes[b].Add(a);
        }

        var subtreeXors = new int[n];

        CalculateSubtreeXor(0, noNode);

        var m = edges.Length;
        var ans = int.MaxValue;

        for (var i = 0; i < m; i++)
        {
            var edge1 = edges[i];
            var node1 = GetChildNode(edge1);

            var xor1 = subtreeXors[0];
            var xor2 = subtreeXors[node1];
            xor1 ^= xor2;

            for (var j = i + 1; j < m; j++)
            {
                var edge2 = edges[j];
                var node2 = GetChildNode(edge2);

                var xor3 = subtreeXors[node2];

                var xors = new[] { xor1, xor2, xor3 };

                if (IsDescendent(node2, node1))
                {
                    xors[1] ^= xors[2];
                }
                else if (IsDescendent(node1, node2))
                {
                    xors[2] ^= xors[1];
                    xors[0] ^= xors[2];
                }
                else
                {
                    xors[0] ^= xors[2];
                }

                ans = Math.Min(ans, xors.Max() - xors.Min());
            }
        }

        return ans;

        int CalculateSubtreeXor(int node, int parent)
        {
            subtreeXors[node] = nums[node];
            parentNodes[node] = parent;

            foreach (var adjNode in adjNodes[node].Where(adjNode => adjNode != parent))
            {
                subtreeXors[node] ^= CalculateSubtreeXor(adjNode, node);
            }

            return subtreeXors[node];
        }

        bool IsDescendent(int node, int possibleAncestor)
        {
            while (node != noNode)
            {
                if (node == possibleAncestor)
                {
                    return true;
                }

                node = parentNodes[node];
            }

            return false;
        }

        int GetChildNode(int[] edge)
        {
            var a = edge[0];
            var b= edge[1];
            if (parentNodes[a] == b)
            {
                return a;
            }
            if (parentNodes[b] == a)
            {
                return b;
            }

            throw new InvalidOperationException("Invalid edge: " + string.Join(", ", edge));
        }
    }
}
