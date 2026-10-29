namespace LeetCode.Problems._3026_Maximum_Good_Subarray_Sum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-123/submissions/detail/1164930488/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 2];
        prefixSums[n + 1] = long.MinValue;

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var map = new Dictionary<int, List<int>>();

        for (var i = n - 1; i >= 0; i--)
        {
            var endNum = nums[i];
            var sum = prefixSums[i + 1];
            map.TryAdd(endNum, new List<int> { n });
            var lastMaxSumIndex = map[endNum][0];
            var lastMaxSum = prefixSums[lastMaxSumIndex + 1];

            if (sum > lastMaxSum)
            {
                map[endNum].Insert(0, i);
            }

        }

        var ans = long.MinValue;

        for (var i = 0; i < n; i++)
        {
            var starNum = nums[i];

            foreach (var endNum in new[] { starNum - k, starNum + k })
            {
                var endNumIndices = map.GetValueOrDefault(endNum, new List<int> { n });
                var indexOfIndex = endNumIndices.BinarySearch(i + 1);

                if (indexOfIndex < 0)
                {
                    indexOfIndex = ~indexOfIndex;
                }

                var j = endNumIndices[indexOfIndex];

                if (j < n)
                {
                    ans = Math.Max(ans, prefixSums[j + 1] - prefixSums[i]);
                }
            }
        }

        return ans == long.MinValue ? 0 : ans;
    }
}
