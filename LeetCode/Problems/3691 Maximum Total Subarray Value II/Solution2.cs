using System.Numerics;

namespace LeetCode.Problems._3691_Maximum_Total_Subarray_Value_II;

/// <summary>
/// https://leetcode.com/problems/maximum-total-subarray-value-ii/submissions/2029943003/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        var sparseTable = new SparseTable(nums);

        var pq = new PriorityQueue<(Range range, int diff), int>();

        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            AddToPq(i, n - 1);
        }

        var ans = 0L;

        for (var i = 0; i < k; i++)
        {
            var (range, diff) = pq.Dequeue();
            ans += diff;

            if (range.Length > 1)
            {
                AddToPq(range.StartIndex, range.EndIndex - 1);
            }
        }

        return ans;

        void AddToPq(int startIndex, int endIndex)
        {
            var diff = sparseTable.MaxMinDiff(startIndex, endIndex);
            var length = endIndex - startIndex + 1;
            pq.Enqueue((new Range(startIndex, length), diff), -diff);
        }
    }

    private class SparseTable
    {
        private readonly Dictionary<Range, int> _rangeMins = new();
        private readonly Dictionary<Range, int> _rangeMaxes = new();
        public SparseTable(int[] nums)
        {
            var n = nums.Length;

            for (var index = 0; index < n; index++)
            {
                var num = nums[index];
                _rangeMins[new Range(index, 1)] = num;
                _rangeMaxes[new Range(index, 1)] = num;
            }

            for (var length = 2; length <= n; length *= 2)
            {
                for (var index = 0; index <= n - length; index++)
                {
                    _rangeMins[new Range(index, length)] = Math.Min(_rangeMins[new Range(index, length / 2)], _rangeMins[new Range(index + length / 2, length / 2)]);
                    _rangeMaxes[new Range(index, length)] = Math.Max(_rangeMaxes[new Range(index, length / 2)], _rangeMaxes[new Range(index + length / 2, length / 2)]);
                }
            }
        }

        private int Min(int startIndex, int endIndex)
        {
            var previousPowerOfTwo = GetPreviousPowerOfTwo(startIndex, endIndex);
            var ans = _rangeMins[new Range(startIndex, previousPowerOfTwo)];

            if (endIndex - previousPowerOfTwo + 1 > startIndex)
            {
                ans = Math.Min(ans, _rangeMins[new Range(endIndex - previousPowerOfTwo + 1, previousPowerOfTwo)]);
            }

            return ans;
        }

        private int Max(int startIndex, int endIndex)
        {
            var previousPowerOfTwo = GetPreviousPowerOfTwo(startIndex, endIndex);
            var ans = _rangeMaxes[new Range(startIndex, previousPowerOfTwo)];

            if (endIndex - previousPowerOfTwo + 1 > startIndex)
            {
                ans = Math.Max(ans, _rangeMaxes[new Range(endIndex - previousPowerOfTwo + 1, previousPowerOfTwo)]);
            }

            return ans;
        }

        public int MaxMinDiff(int startIndex, int endIndex) => Max(startIndex, endIndex) - Min(startIndex, endIndex);

        private static int GetPreviousPowerOfTwo(int startIndex, int endIndex)
        {
            var length = endIndex - startIndex + 1;
            ArgumentOutOfRangeException.ThrowIfLessThan(length, 0);
            var nextPowerOfTwo = BitOperations.RoundUpToPowerOf2((uint) length);
            var previousPowerOfTwo = nextPowerOfTwo == length ? nextPowerOfTwo : nextPowerOfTwo / 2;
            return (int) previousPowerOfTwo;
        }
    }

    private readonly record struct Range(int StartIndex, int Length)
    {
        public int EndIndex => StartIndex + Length - 1;
    }
}
