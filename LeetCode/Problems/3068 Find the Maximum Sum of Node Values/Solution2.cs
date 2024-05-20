using JetBrains.Annotations;

namespace LeetCode.Problems._3068_Find_the_Maximum_Sum_of_Node_Values;

/// <summary>
/// https://leetcode.com/submissions/detail/1261921851/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution2 : ISolution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        var n = edges.Length + 1;

        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjNodes[u].Add(v);
            adjNodes[v].Add(u);
        }

        var maxChildNodesCount = 0;

        var root = BuildNode(0, -1);

        var boolEnumerables = new IEnumerable<bool>[maxChildNodesCount + 1][];
        boolEnumerables[0] = new IEnumerable<bool>[] { Array.Empty<bool>() };

        for (var i = 1; i <= maxChildNodesCount; i++)
        {
            var previousArrays = boolEnumerables[i - 1];
            boolEnumerables[i] = new IEnumerable<bool>[2 * previousArrays.Length];

            for (var j = 0; j < previousArrays.Length; j++)
            {
                boolEnumerables[i][j] = previousArrays[j].Append(false);
                boolEnumerables[i][j + previousArrays.Length] = previousArrays[j].Append(true);
            }
        }

        var dp = new DynamicProgramming<(Node node, bool isParentNodeEdgeSelected), long>((key, recursiveFunc) =>
        {
            var (node, isParentNodeEdgeSelected) = key;

            var ans = 0L;

            var m = node.ChildNodes.Length;

            foreach (var boolEnumerable in boolEnumerables[m])
            {
                var sum = 0L;
                var shouldUpdateNodeValue = isParentNodeEdgeSelected;

                var i = 0;

                foreach (var isEdgeTaken in boolEnumerable)
                {
                    shouldUpdateNodeValue ^= isEdgeTaken;
                    sum += recursiveFunc((node.ChildNodes[i], isEdgeTaken));
                    i++;
                }

                sum += shouldUpdateNodeValue ? node.Value ^ k : node.Value;
                ans = Math.Max(ans, sum);
            }

            return ans;
        });

        return dp.GetOrCalculate((root, false));

        Node BuildNode(int id, int parent)
        {
            var childNodes = adjNodes[id].Except(new[] { parent }).Select(childNode => BuildNode(childNode, id)).ToArray();
            maxChildNodesCount = Math.Max(maxChildNodesCount, childNodes.Length);
            return new Node(nums[id], childNodes);
        }
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

    private record Node(int Value, Node[] ChildNodes);
}
