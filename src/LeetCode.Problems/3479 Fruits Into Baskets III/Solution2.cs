namespace LeetCode.Problems._3479_Fruits_Into_Baskets_III;

/// <summary>
/// https://leetcode.com/problems/fruits-into-baskets-iii/submissions/1726264838/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var segmentTree = new SegmentTree<int>(baskets, Math.Max, int.MinValue);

        var ans = 0;

        foreach (var fruit in fruits)
        {
            var low = 0;
            var high = baskets.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);
                if (segmentTree.Query(0, mid) < fruit)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (low < baskets.Length && segmentTree.Query(0, low) >= fruit)
            {
                segmentTree.Update(low, int.MinValue);
            }
            else
            {
                ans++;
            }
        }

        return ans;
    }

    private class SegmentTree<T>
    {
        private readonly int _n;
        private readonly T[] _tree;
        private readonly Func<T, T, T> _merge;
        private readonly T _identity;

        public SegmentTree(T[] data, Func<T, T, T> merge, T identity)
        {
            _merge = merge;
            _identity = identity;
            _n = data.Length;
            _tree = new T[_n * 4];
            Build(1, 0, _n - 1, data);
        }

        private void Build(int node, int l, int r, T[] data)
        {
            if (l == r)
            {
                _tree[node] = data[l];
                return;
            }

            var mid = l + (r - l >> 1);
            Build(node * 2, l, mid, data);
            Build(node * 2 + 1, mid + 1, r, data);
            _tree[node] = _merge(_tree[node * 2], _tree[node * 2 + 1]);
        }

        public T Query(int ql, int qr) => Query(1, 0, _n - 1, ql, qr);

        private T Query(int node, int l, int r, int ql, int qr)
        {
            if (qr < l || r < ql)
            {
                return _identity;
            }

            if (ql <= l && r <= qr)
            {
                return _tree[node];
            }

            var mid = l + (r - l >> 1);
            var left = Query(node * 2, l, mid, ql, qr);
            var right = Query(node * 2 + 1, mid + 1, r, ql, qr);
            return _merge(left, right);
        }

        public void Update(int idx, T value) => Update(1, 0, _n - 1, idx, value);

        private void Update(int node, int l, int r, int idx, T value)
        {
            if (l == r)
            {
                _tree[node] = value;
                return;
            }
            var mid = l + (r - l >> 1);

            if (idx <= mid)
            {
                Update(node * 2, l, mid, idx, value);
            }
            else
            {
                Update(node * 2 + 1, mid + 1, r, idx, value);
            }
            _tree[node] = _merge(_tree[node * 2], _tree[node * 2 + 1]);
        }
    }
}
