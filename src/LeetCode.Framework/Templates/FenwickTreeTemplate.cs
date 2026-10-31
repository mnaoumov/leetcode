// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class FenwickTreeTemplate
{
    // Point update and prefix sum over positions [0, n), both O(log n). For range updates or min/max, use a segment tree.
    public sealed class FenwickTree(int n)
    {
        private readonly long[] _tree = new long[n + 1];

        public void Add(int index, long delta)
        {
            for (var i = index + 1; i <= n; i += i & -i)
            {
                _tree[i] += delta;
            }
        }

        /// <summary>The sum over [0, count).</summary>
        public long PrefixSum(int count)
        {
            var sum = 0L;

            for (var i = count; i > 0; i -= i & -i)
            {
                sum += _tree[i];
            }

            return sum;
        }

        /// <summary>The sum over [from, to).</summary>
        public long Sum(int from, int to) => PrefixSum(to) - PrefixSum(from);
    }
}
