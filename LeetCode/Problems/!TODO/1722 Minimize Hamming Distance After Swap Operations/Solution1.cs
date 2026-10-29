namespace LeetCode.Problems._1722_Minimize_Hamming_Distance_After_Swap_Operations;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        var n = source.Length;

        var uf = new UnionFind<int>();

        foreach (var allowedSwap in allowedSwaps)
        {
            var a = allowedSwap[0];
            var b = allowedSwap[1];
            uf.Union(a, b);
        }

        var components = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            var root = uf.Find(i);
            components.TryAdd(root, new List<int>());
            components[root].Add(i);
        }

        var ans = 0;

        foreach (var component in components.Values)
        {
            var targetCounts = component.Select(index => target[index]).GroupBy(num => num)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var sourceNum in component.Select(index => source[index]))
            {
                if (targetCounts.TryGetValue(sourceNum, out var count))
                {
                    if (count == 1)
                    {
                        targetCounts.Remove(sourceNum);
                    }
                    else
                    {
                        targetCounts[sourceNum] = count - 1;
                    }
                }
            }

            ans += targetCounts.Values.Sum();
        }

        return ans;
    }

    private sealed class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        public T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

        public void Union(T x, T y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX.Equals(rootY))
            {
                return;
            }

            var rankX = GetRank(rootX);
            var rankY = GetRank(rootY);

            if (rankX < rankY)
            {
                _roots[rootX] = rootY;
            }
            else if (rankX > rankY)
            {
                _roots[rootY] = rootX;
            }
            else
            {
                _roots[rootX] = rootY;
                _ranks[rootY] = rankY + 1;
            }
        }

        private int GetRank(T x) => _ranks.GetValueOrDefault(x, 1);
    }
}
