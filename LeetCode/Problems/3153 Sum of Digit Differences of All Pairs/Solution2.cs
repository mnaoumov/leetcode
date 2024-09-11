namespace LeetCode.Problems._3153_Sum_of_Digit_Differences_of_All_Pairs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-398/submissions/detail/1261819951/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long SumDigitDifferences(int[] nums)
    {
        var ans = 0L;
        var n = nums.Length;

        while (nums[0] > 0)
        {
            var digitCounts = new int[10];

            for (var j = 0; j < n; j++)
            {
                var digit = nums[j] % 10;
                digitCounts[digit]++;
                nums[j] /= 10;
            }

            ans += digitCounts.Select(count => 1L * count * (n - count)).Sum() / 2;
        }

        return ans;
    }
}
