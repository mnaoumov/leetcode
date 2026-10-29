namespace LeetCode.Problems._2996_Smallest_Missing_Integer_Greater_Than_Sequential_Prefix_Sum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-121/submissions/detail/1138532986/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MissingInteger(int[] nums)
    {
        var n = nums.Length;

        var prefixSum = nums[0];

        for (var i = 1; i < n; i++)
        {
            if (nums[i] != nums[i - 1] + 1)
            {
                break;
            }

            prefixSum += nums[i];
        }

        var set = nums.ToHashSet();

        for (var x = prefixSum; ; x++)
        {
            if (!set.Contains(x))
            {
                return x;
            }
        }
    }
}
