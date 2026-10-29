namespace LeetCode.Problems._1283_Find_the_Smallest_Divisor_Given_a_Threshold;

/// <summary>
/// https://leetcode.com/submissions/detail/915116979/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestDivisor(int[] nums, int threshold)
    {
        var low = 1;
        var high = 1_000_000;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var sum = nums.Sum(num => (0L + num + mid - 1) / mid);

            if (sum > threshold)
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
}
