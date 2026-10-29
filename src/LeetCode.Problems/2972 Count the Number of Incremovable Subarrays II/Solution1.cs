namespace LeetCode.Problems._2972_Count_the_Number_of_Incremovable_Subarrays_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-120/submissions/detail/1126702757/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long IncremovableSubarrayCount(int[] nums)
    {
        var validSuffixes = new List<int> { int.MaxValue };

        var n = nums.Length;

        for (var i = n - 1; i >= 0; i--)
        {
            var num = nums[i];

            if (num >= validSuffixes[0])
            {
                break;
            }

            validSuffixes.Insert(0, num);
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            var lastTaken = i == 0 ? int.MinValue : nums[i - 1];

            var firstSuffixIndex = validSuffixes.BinarySearch(lastTaken + 1);

            if (firstSuffixIndex < 0)
            {
                firstSuffixIndex = ~firstSuffixIndex;
            }

            var firstSuffixNumIndex = firstSuffixIndex + n + 1 - validSuffixes.Count;

            if (firstSuffixNumIndex == i)
            {
                firstSuffixIndex++;
            }

            ans += validSuffixes.Count - firstSuffixIndex;

            if (nums[i] <= lastTaken)
            {
                break;
            }
        }

        return ans;

    }
}
