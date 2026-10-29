namespace LeetCode.Problems._1829_Maximum_XOR_for_Each_Query;

/// <summary>
/// https://leetcode.com/submissions/detail/1446349797/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        var n = nums.Length;
        var ans = new int[n];

        var totalXor = 0;
        var allBits = (1 << maximumBit) - 1;

        for (var i = 0; i < n; i++)
        {
            totalXor ^= nums[i];
            ans[^(i + 1)] = totalXor ^ allBits;
        }
        return ans;
    }
}
