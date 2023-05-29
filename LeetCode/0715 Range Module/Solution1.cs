using JetBrains.Annotations;

namespace LeetCode._0715_Range_Module;

/// <summary>
/// https://leetcode.com/submissions/detail/959257990/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IRangeModule Create() => new RangeModule();

    private class RangeModule : IRangeModule
    {
        private readonly List<(int left, int right)> _intervals = new();

        public RangeModule()
        {
            _intervals.Add((int.MinValue, int.MinValue));
            _intervals.Add((int.MaxValue, int.MaxValue));
        }

        public void AddRange(int left, int right)
        {
            var (leftIndex, rightIndex) = FindRange(left, right);

            var previous = _intervals[leftIndex - 1];
            var next = _intervals[rightIndex];

            if (previous.right >= left)
            {
                leftIndex--;
            }

            if (next.left > right)
            {
                rightIndex--;
            }

            left = Math.Min(left, _intervals[leftIndex].left);
            right = Math.Max(right, _intervals[rightIndex].right);
            _intervals.RemoveRange(leftIndex, rightIndex - leftIndex + 1);
            _intervals.Insert(leftIndex, (left, right));
        }

        private (int leftIndex, int rightIndex) FindRange(int left, int right)
        {
            var leftIndex = FindInterval(left, true);
            var rightIndex = FindInterval(right, false);
            return (leftIndex, rightIndex);
        }

        private int FindInterval(int value, bool searchByLeft)
        {
            var low = 0;
            var high = _intervals.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if ((searchByLeft ? _intervals[mid].left : _intervals[mid].right) <= value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low;
        }

        public bool QueryRange(int left, int right)
        {
            var (leftIndex, _) = FindRange(left, right);
            var previous = _intervals[leftIndex - 1];
            return previous.right >= right;
        }

        public void RemoveRange(int left, int right)
        {
            var (leftIndex, rightIndex) = FindRange(left, right);

            var previous = _intervals[leftIndex - 1];
            var next = _intervals[rightIndex];

            if (previous.right > left)
            {
                _intervals[leftIndex - 1] = (previous.left, left);
            }

            if (next.left < right)
            {
                if (leftIndex - 1 == rightIndex)
                {
                    _intervals.Insert(leftIndex, (right, next.right));
                }
                else
                {
                    _intervals[rightIndex] = (right, next.right);
                }
            }

            if (rightIndex > leftIndex)
            {
                _intervals.RemoveRange(leftIndex, rightIndex - leftIndex);
            }
        }
    }
}
