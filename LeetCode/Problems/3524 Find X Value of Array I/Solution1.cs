namespace LeetCode.Problems._3524_Find_X_Value_of_Array_I;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long[] ResultArray(int[] nums, int k)
    {
        var n = nums.Length;
        var ans = new long[k];

        var x = new int[k];

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            var remainder = num % k;

            if (remainder == 0)
            {
                ans[0] += i;
            }
        }

        return ans;
    }
}
