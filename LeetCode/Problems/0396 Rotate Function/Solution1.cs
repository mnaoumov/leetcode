namespace LeetCode.Problems._0396_Rotate_Function;

/// <summary>
/// https://leetcode.com/problems/rotate-function/submissions/1992870529/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxRotateFunction(int[] nums)
    {
        var f = 0;
        var n = nums.Length;
        var numSum = nums.Sum();
        for (var i = 0; i < n; i++)
        {
            f += i * nums[i];
        }

        var ans = f;
        for (var i = n - 1; i > 0; i--)
        {
            f += numSum - n * nums[i];
            ans = Math.Max(ans, f);
        }
        return ans;
    }
}