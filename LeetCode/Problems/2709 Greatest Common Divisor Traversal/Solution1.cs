using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._2709_Greatest_Common_Divisor_Traversal;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-105/submissions/detail/958371647/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool CanTraverseAllPairs(int[] nums)
    {
        var uf = new UnionFind<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (BigInteger.GreatestCommonDivisor(nums[i], nums[j]) > 1)
                {
                    uf.Union(i, j);
                }
            }
        }

        for (var i = 1; i < nums.Length; i++)
        {
            if (!uf.Connected(0, i))
            {
                return false;
            }
        }

        return true;
    }

    private class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        private T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

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

        public bool Connected(T x, T y) => Find(x).Equals(Find(y));
    }
}
