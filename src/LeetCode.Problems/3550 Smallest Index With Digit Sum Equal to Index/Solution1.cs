namespace LeetCode.Problems._3550_Smallest_Index_With_Digit_Sum_Equal_to_Index;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-450/problems/smallest-index-with-digit-sum-equal-to-index/submissions/1636858436/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestIndex(int[] nums) => Enumerable.Range(0, nums.Length).FirstOrDefault(i => DigitSum(nums[i]) == i, -1);

    private static int DigitSum(int num)
    {
        var ans = 0;
        while (num > 0)
        {
            ans += num % 10;
            num /= 10;
        }

        return ans;
    }
}
