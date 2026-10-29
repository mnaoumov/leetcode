namespace LeetCode.Problems._3644_Maximum_K_to_Sort_a_Permutation;

/// <summary>
/// https://leetcode.com/problems/maximum-k-to-sort-a-permutation/submissions/2180059046/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SortPermutation(int[] nums)
    {
        var ans = int.MaxValue;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == i)
            {
                continue;
            }

            ans &= i;
        }

        return ans == int.MaxValue ? 0 : ans;
    }
}
