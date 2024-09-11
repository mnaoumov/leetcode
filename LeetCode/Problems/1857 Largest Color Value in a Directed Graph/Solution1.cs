namespace LeetCode.Problems._1857_Largest_Color_Value_in_a_Directed_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/930413851/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        var n = colors.Length;

        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
        }

        var seen = new bool[n];
        var reverseTopologicalOrder = new List<int>();

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            if (!Dfs(i))
            {
                return -1;
            }
        }

        var distinctColors = colors.Distinct().ToArray();

        var dp = new DynamicProgramming<(int node, int color), int>((key, recursiveFunc) =>
        {
            var (node, color) = key;
            return (colors[node] == color ? 1 : 0) +
                   adjacentNodes[node].Select(adjacentNode => recursiveFunc((adjacentNode, color))).Prepend(0).Max();
        });

        return reverseTopologicalOrder.SelectMany(_ => distinctColors, (node, color) => dp.GetOrCalculate((node, color))).Max();

        bool Dfs(int node)
        {
            if (seen[node])
            {
                return false;
            }

            seen[node] = true;

            if (adjacentNodes[node].Any(adjacentNode => !Dfs(adjacentNode)))
            {
                return false;
            }

            reverseTopologicalOrder.Add(node);
            return true;
        }
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
