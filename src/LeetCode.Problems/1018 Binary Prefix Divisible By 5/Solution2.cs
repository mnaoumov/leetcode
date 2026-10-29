namespace LeetCode.Problems._1018_Binary_Prefix_Divisible_By_5;

/// <summary>
/// https://leetcode.com/problems/binary-prefix-divisible-by-5/submissions/1838067745/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        var n = nums.Length;
        var ans = new bool[n];

        var num = 0;

        for (var i = 0; i < n; i++)
        {
            num = (2 * num + nums[i]) % 5;
            ans[i] = num == 0;
        }

        return ans;
    }
}
