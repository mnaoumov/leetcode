namespace LeetCode.Problems._3721_Longest_Balanced_Subarray_II;

/// <summary>
/// https://leetcode.com/problems/longest-balanced-subarray-ii/submissions/1915292024/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestBalanced(int[] nums)
    {
        var occurrences = new Dictionary<int, Queue<int>>();

        var len = 0;
        var prefixSum = new int[nums.Length];
        prefixSum[0] = Sgn(nums[0]);
        occurrences.TryAdd(nums[0], new Queue<int>());
        occurrences[nums[0]].Enqueue(1);

        for (var i = 1; i < nums.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1];
            occurrences.TryAdd(nums[i], new Queue<int>());
            var occ = occurrences[nums[i]];
            if (occ.Count == 0)
            {
                prefixSum[i] += Sgn(nums[i]);
            }
            occ.Enqueue(i + 1);
        }

        var seg = new SegmentTree(prefixSum);
        for (var i = 0; i < nums.Length; i++)
        {
            len = Math.Max(len, seg.FindLast(i + len, 0) - i);

            var nextPos = nums.Length + 1;
            occurrences[nums[i]].Dequeue();
            if (occurrences[nums[i]].Count > 0)
            {
                nextPos = occurrences[nums[i]].Peek();
            }

            seg.Add(i + 1, nextPos - 1, -Sgn(nums[i]));
        }

        return len;
    }

    private static int Sgn(int x) => (x % 2) == 0 ? 1 : -1;

    private class LazyTag
    {
        public LazyTag(int value = 0) => Value = value;
        public int Value { get; private set; }
        public void Add(LazyTag other) => Value += other.Value;
        public bool HasTag() => Value != 0;
        public void Clear() => Value = 0;
    }

    private class SegmentTreeNode
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public LazyTag LazyTag { get; } = new();
    }

    private class SegmentTree
    {
        private readonly int _size;
        private readonly SegmentTreeNode[] _tree;

        public SegmentTree(int[] data)
        {
            _size = data.Length;
            _tree = new SegmentTreeNode[_size * 4 + 1];
            for (var i = 0; i < _tree.Length; i++)
            {
                _tree[i] = new SegmentTreeNode();
            }
            Build(data, 1, _size, 1);
        }

        public void Add(int l, int r, int val)
        {
            var tag = new LazyTag(val);
            Update(l, r, tag, 1, _size, 1);
        }

        public int FindLast(int start, int val)
        {
            if (start > _size)
            {
                return -1;
            }
            return Find(start, _size, val, 1, _size, 1);
        }

        private void ApplyTag(int i, LazyTag tag)
        {
            _tree[i].MinValue += tag.Value;
            _tree[i].MaxValue += tag.Value;
            _tree[i].LazyTag.Add(tag);
        }

        private void Pushdown(int i)
        {
            if (!_tree[i].LazyTag.HasTag())
            {
                return;
            }

            var tag = new LazyTag(_tree[i].LazyTag.Value);
            ApplyTag(i << 1, tag);
            ApplyTag((i << 1) | 1, tag);
            _tree[i].LazyTag.Clear();
        }

        private void PushUp(int i)
        {
            _tree[i].MinValue =
                Math.Min(_tree[i << 1].MinValue, _tree[(i << 1) | 1].MinValue);
            _tree[i].MaxValue =
                Math.Max(_tree[i << 1].MaxValue, _tree[(i << 1) | 1].MaxValue);
        }

        private void Build(int[] data, int l, int r, int i)
        {
            if (l == r)
            {
                _tree[i].MinValue = _tree[i].MaxValue = data[l - 1];
                return;
            }

            var mid = l + ((r - l) >> 1);
            Build(data, l, mid, i << 1);
            Build(data, mid + 1, r, (i << 1) | 1);
            PushUp(i);
        }

        private void Update(int targetL, int targetR, LazyTag tag, int l, int r, int i)
        {
            if (targetL <= l && r <= targetR)
            {
                ApplyTag(i, tag);
                return;
            }

            Pushdown(i);
            var mid = l + ((r - l) >> 1);

            if (targetL <= mid)
            {
                Update(targetL, targetR, tag, l, mid, i << 1);
            }

            if (targetR > mid)
            {
                Update(targetL, targetR, tag, mid + 1, r, (i << 1) | 1);
            }

            PushUp(i);
        }

        private int Find(int targetL, int targetR, int val, int l, int r, int i)
        {
            if (_tree[i].MinValue > val || _tree[i].MaxValue < val)
            {
                return -1;
            }

            if (l == r)
            {
                return l;
            }

            Pushdown(i);
            var mid = l + ((r - l) >> 1);

            if (targetR >= mid + 1)
            {
                var res = Find(targetL, targetR, val, mid + 1, r, (i << 1) | 1);

                if (res != -1)
                {
                    return res;
                }
            }

            if (l > targetR || mid < targetL)
            {
                return -1;
            }

            // ReSharper disable once TailRecursiveCall
            return Find(targetL, targetR, val, l, mid, i << 1);
        }
    }
}
