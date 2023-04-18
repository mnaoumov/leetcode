using JetBrains.Annotations;

namespace LeetCode._1712_Ways_to_Split_Array_Into_Three_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/935899698/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int WaysToSplit(int[] nums)
    {
        var n = nums.Length;
        var prefixSums = new int[n];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i] = (i > 0 ? prefixSums[i - 1] : 0) + nums[i];
        }

        const int modulo = 1_000_000_007;
        var result = 0;

        for (var i = 0; i < n - 2; i++)
        {
            var sum1 = prefixSums[i];

            var min = 2 * sum1;
            var max = (prefixSums[n - 1] + prefixSums[i]) / 2;

            if (min > max)
            {
                break;
            }

            var low = i + 1;
            var high = n - 2;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (prefixSums[mid] >= min)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var minIndex = low;

            low = minIndex;
            high = n - 2;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (prefixSums[mid] <= max)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            var maxIndex = high;

            if (minIndex <= maxIndex)
            {
                result = (result + maxIndex - minIndex + 1) % modulo;
            }
        }

        return result;
    }
}
