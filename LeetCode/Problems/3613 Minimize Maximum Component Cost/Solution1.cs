namespace LeetCode.Problems._3613_Minimize_Maximum_Component_Cost;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-458/problems/minimize-maximum-component-cost/submissions/1695831340/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int n, int[][] edges, int k)
    {
        var edgeObjs = edges.Select(arr => new Edge(arr[0], arr[1], arr[2])).ToArray();
        var weights = new SortedSet<int>(edgeObjs.Select(e => e.Weight));

        var low = 0;
        var high = weights.Max;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

            if (CanFormComponents(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanFormComponents(int maxWeight)
        {
            var unionFind = new UnionFind<int>();
            foreach (var edge in edgeObjs)
            {
                if (edge.Weight <= maxWeight)
                {
                    unionFind.Union(edge.Node1, edge.Node2);
                }
            }
            var componentCount = new HashSet<int>();
            for (var i = 0; i < n; i++)
            {
                componentCount.Add(unionFind.Find(i));

                if (componentCount.Count > k)
                {
                    return false;
                }
            }

            return true;
        }
    }

    private record Edge(int Node1, int Node2, int Weight);

    private class UnionFind<T> where T : IEquatable<T>
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
