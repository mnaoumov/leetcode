// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class SegmentTreeTemplate
{
    // Lazy propagation over positions [0, n), all half-open: Add and Assign update [from, to), Sum, Min and Max query it.
    // Every update and query is O(log n).
    public sealed class SegmentTree
    {
        private readonly int _n;
        private readonly long[] _sums;
        private readonly long[] _mins;
        private readonly long[] _maxes;
        private readonly long[] _pendingAdds;
        private readonly long[] _pendingAssigns;
        private readonly bool[] _hasPendingAssign;

        public SegmentTree(int n) : this(new long[n])
        {
        }

        public SegmentTree(IReadOnlyList<long> values)
        {
            _n = values.Count;
            var size = 4 * Math.Max(_n, 1);
            _sums = new long[size];
            _mins = new long[size];
            _maxes = new long[size];
            _pendingAdds = new long[size];
            _pendingAssigns = new long[size];
            _hasPendingAssign = new bool[size];

            if (_n > 0)
            {
                Build(1, 0, _n, values);
            }
        }

        public void Add(int from, int to, long delta) => Update(1, 0, _n, from, to, null, delta);

        public void Assign(int from, int to, long value) => Update(1, 0, _n, from, to, value, 0);

        public long Sum(int from, int to) => Query(1, 0, _n, from, to).Sum;

        public long Min(int from, int to) => Query(1, 0, _n, from, to).Min;

        public long Max(int from, int to) => Query(1, 0, _n, from, to).Max;

        private void Build(int node, int left, int right, IReadOnlyList<long> values)
        {
            if (right - left == 1)
            {
                _sums[node] = _mins[node] = _maxes[node] = values[left];
                return;
            }

            var mid = left + (right - left) / 2;
            Build(2 * node, left, mid, values);
            Build(2 * node + 1, mid, right, values);
            Pull(node);
        }

        private void Update(int node, int left, int right, int from, int to, long? assign, long add)
        {
            if (to <= left || right <= from)
            {
                return;
            }

            if (from <= left && right <= to)
            {
                Apply(node, right - left, assign, add);
                return;
            }

            Push(node, left, right);
            var mid = left + (right - left) / 2;
            Update(2 * node, left, mid, from, to, assign, add);
            Update(2 * node + 1, mid, right, from, to, assign, add);
            Pull(node);
        }

        private (long Sum, long Min, long Max) Query(int node, int left, int right, int from, int to)
        {
            if (to <= left || right <= from)
            {
                return (0, long.MaxValue, long.MinValue);
            }

            if (from <= left && right <= to)
            {
                return (_sums[node], _mins[node], _maxes[node]);
            }

            Push(node, left, right);
            var mid = left + (right - left) / 2;
            var (sum1, min1, max1) = Query(2 * node, left, mid, from, to);
            var (sum2, min2, max2) = Query(2 * node + 1, mid, right, from, to);
            return (sum1 + sum2, Math.Min(min1, min2), Math.Max(max1, max2));
        }

        // The pending update of a node is "assign (if any), then add".
        private void Apply(int node, int length, long? assign, long add)
        {
            if (assign is { } value)
            {
                _sums[node] = value * length;
                _mins[node] = _maxes[node] = value;
                _pendingAssigns[node] = value;
                _hasPendingAssign[node] = true;
                _pendingAdds[node] = 0;
            }

            if (add == 0)
            {
                return;
            }

            _sums[node] += add * length;
            _mins[node] += add;
            _maxes[node] += add;
            _pendingAdds[node] += add;
        }

        private void Push(int node, int left, int right)
        {
            long? assign = _hasPendingAssign[node] ? _pendingAssigns[node] : null;
            var add = _pendingAdds[node];

            if (assign == null && add == 0)
            {
                return;
            }

            var mid = left + (right - left) / 2;
            Apply(2 * node, mid - left, assign, add);
            Apply(2 * node + 1, right - mid, assign, add);
            _hasPendingAssign[node] = false;
            _pendingAdds[node] = 0;
        }

        private void Pull(int node)
        {
            _sums[node] = _sums[2 * node] + _sums[2 * node + 1];
            _mins[node] = Math.Min(_mins[2 * node], _mins[2 * node + 1]);
            _maxes[node] = Math.Max(_maxes[2 * node], _maxes[2 * node + 1]);
        }
    }
}
