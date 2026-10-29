namespace LeetCode.Problems._3640_Trionic_Array_II;

/// <summary>
/// https://leetcode.com/problems/trionic-array-ii/submissions/1907356925/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxSumTrionic(int[] nums)
    {
        var n = nums.Length;

        var intervals = new List<Interval> { new(-1, -1, Direction.None) };

        for (var i = 0; i < n - 1; i++)
        {
            var num = nums[i];
            var next = nums[i + 1];
            var direction = num.CompareTo(next) switch
            {
                < 0 => Direction.Increasing,
                > 0 => Direction.Decreasing,
                _ => Direction.None
            };

            if (intervals[^1].Direction != direction)
            {
                intervals.Add(new Interval(i, i + 1, direction));
            }
            else
            {
                intervals[^1] = intervals[^1] with { EndIndex = i + 1 };
            }
        }

        var ans = long.MinValue;

        for (var i = 0; i < intervals.Count - 2; i++)
        {
            if (intervals[i].Direction == Direction.Increasing && intervals[i + 1].Direction == Direction.Decreasing &&
                intervals[i + 2].Direction == Direction.Increasing)
            {
                ans = Math.Max(ans,
                    intervals[i].GetMaxSuffixSum(nums)
                    + intervals[i + 1].GetTotalSum(nums)
                    + intervals[i + 2].GetMaxPrefixSum(nums)
                    - nums[intervals[i].EndIndex]
                    - nums[intervals[i + 1].EndIndex]);
            }
        }

        return ans;
    }

    private record Interval(int StartIndex, int EndIndex, Direction Direction)
    {
        public long GetMaxSuffixSum(int[] nums)
        {
            var sum = 0L + nums[EndIndex] + nums[EndIndex - 1];
            var maxSum = sum;

            for (var i = EndIndex - 2; i >= StartIndex; i--)
            {
                sum += nums[i];
                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }

        public long GetTotalSum(int[] nums)
        {
            var sum = 0L;

            for (var i = StartIndex; i <= EndIndex; i++)
            {
                sum += nums[i];
            }

            return sum;
        }

        public long GetMaxPrefixSum(int[] nums)
        {
            var sum = 0L + nums[StartIndex] + nums[StartIndex + 1];
            var maxSum = sum;

            for (var i = StartIndex + 2; i <= EndIndex; i++)
            {
                sum += nums[i];
                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }
    }

    private enum Direction
    {
        Increasing,
        Decreasing,
        None
    }
}
