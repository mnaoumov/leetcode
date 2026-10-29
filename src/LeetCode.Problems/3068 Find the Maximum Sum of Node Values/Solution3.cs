namespace LeetCode.Problems._3068_Find_the_Maximum_Sum_of_Node_Values;

/// <summary>
/// https://leetcode.com/submissions/detail/1262002125/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
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

        var root = BuildNode(0, -1);

        var dp = new DynamicProgramming<(Node node, bool isParentNodeEdgeSelected), long>((key, recursiveFunc) =>
        {
            var (node, isParentNodeEdgeSelected) = key;

            var evenEdgeCountNodeValue = isParentNodeEdgeSelected ? node.Value ^ k : node.Value;
            var oddEdgeCountNodeValue = evenEdgeCountNodeValue ^ k;
            var maxNodeValue = Math.Max(evenEdgeCountNodeValue, oddEdgeCountNodeValue);
            var penalty = 0L + Math.Abs(evenEdgeCountNodeValue - oddEdgeCountNodeValue);

            var doesMaxChildSumHaveEvenEdgesCount = true;
            var maxChildSum = 0L;

            foreach (var childNode in node.ChildNodes)
            {
                var resultWithoutEdge = recursiveFunc((childNode, false));
                var resultWithEdge = recursiveFunc((childNode, true));

                if (resultWithEdge > resultWithoutEdge)
                {
                    doesMaxChildSumHaveEvenEdgesCount ^= true;
                }

                maxChildSum += Math.Max(resultWithEdge, resultWithoutEdge);
                var childNodePenalty = Math.Abs(resultWithEdge - resultWithoutEdge);
                penalty = Math.Min(penalty, childNodePenalty);
            }

            var canHaveMaxResult = evenEdgeCountNodeValue >= oddEdgeCountNodeValue == doesMaxChildSumHaveEvenEdgesCount;
            return maxNodeValue + maxChildSum - (canHaveMaxResult ? 0 : penalty);
        });

        return dp.GetOrCalculate((root, false));

        Node BuildNode(int id, int parent)
        {
            var childNodes = adjNodes[id].Except(new[] { parent }).Select(childNode => BuildNode(childNode, id)).ToArray();
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
