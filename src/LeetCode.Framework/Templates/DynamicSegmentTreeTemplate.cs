// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class DynamicSegmentTreeTemplate
{
    // The lazy segment tree over coordinates [low, high), every one starting at 0, with nodes created on demand,
    // so coordinates up to 10^9 need no compression step. All ranges are half-open; each call is O(log(high - low))
    // and creates at most that many nodes.
    public sealed class DynamicSegmentTree(long low, long high)
    {
        private readonly Node _root = new();

        public void Add(long from, long to, long delta) => Update(_root, low, high, from, to, null, delta);

        public void Assign(long from, long to, long value) => Update(_root, low, high, from, to, value, 0);

        public long Sum(long from, long to) => Query(_root, low, high, from, to).Sum;

        public long Min(long from, long to) => Query(_root, low, high, from, to).Min;

        public long Max(long from, long to) => Query(_root, low, high, from, to).Max;

        private static void Update(Node node, long left, long right, long from, long to, long? assign, long add)
        {
            if (to <= left || right <= from)
            {
                return;
            }

            if (from <= left && right <= to)
            {
                node.Apply(right - left, assign, add);
                return;
            }

            var mid = left + (right - left) / 2;
            node.Push(left, mid, right);
            Update(node.Left!, left, mid, from, to, assign, add);
            Update(node.Right!, mid, right, from, to, assign, add);
            node.Pull();
        }

        private static (long Sum, long Min, long Max) Query(Node node, long left, long right, long from, long to)
        {
            if (to <= left || right <= from)
            {
                return (0, long.MaxValue, long.MinValue);
            }

            if (from <= left && right <= to)
            {
                return (node.Sum, node.Min, node.Max);
            }

            var mid = left + (right - left) / 2;
            node.Push(left, mid, right);
            var (sum1, min1, max1) = Query(node.Left!, left, mid, from, to);
            var (sum2, min2, max2) = Query(node.Right!, mid, right, from, to);
            return (sum1 + sum2, Math.Min(min1, min2), Math.Max(max1, max2));
        }

        private sealed class Node
        {
            public Node? Left { get; private set; }
            public Node? Right { get; private set; }
            public long Sum { get; private set; }
            public long Min { get; private set; }
            public long Max { get; private set; }
            private long? _pendingAssign;
            private long _pendingAdd;

            // The pending update of a node is "assign (if any), then add".
            public void Apply(long length, long? assign, long add)
            {
                if (assign is { } value)
                {
                    Sum = value * length;
                    Min = Max = value;
                    _pendingAssign = value;
                    _pendingAdd = 0;
                }

                if (add == 0)
                {
                    return;
                }

                Sum += add * length;
                Min += add;
                Max += add;
                _pendingAdd += add;
            }

            public void Push(long left, long mid, long right)
            {
                Left ??= new Node();
                Right ??= new Node();

                if (_pendingAssign == null && _pendingAdd == 0)
                {
                    return;
                }

                Left.Apply(mid - left, _pendingAssign, _pendingAdd);
                Right.Apply(right - mid, _pendingAssign, _pendingAdd);
                _pendingAssign = null;
                _pendingAdd = 0;
            }

            public void Pull()
            {
                Sum = Left!.Sum + Right!.Sum;
                Min = Math.Min(Left.Min, Right.Min);
                Max = Math.Max(Left.Max, Right.Max);
            }
        }
    }
}
