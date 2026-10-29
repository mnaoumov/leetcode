namespace LeetCode.Problems._3637_Trionic_Array_I;

/// <summary>
/// https://leetcode.com/problems/trionic-array-i/submissions/1906055726/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsTrionic(int[] nums)
    {
        var n = nums.Length;

        var p = 0;

        while (p < n - 1)
        {
            if (nums[p + 1] <= nums[p])
            {
                break;
            }

            p++;
        }

        if (p == 0 || p > n - 3)
        {
            return false;
        }

        var q = p + 1;

        while (q < n - 1)
        {
            if (nums[q + 1] >= nums[q])
            {
                break;
            }

            q++;
        }

        if (q > n - 2)
        {
            return false;
        }

        for (var i = q; i < n - 1; i++)
        {
            if (nums[i + 1] <= nums[i])
            {
                return false;
            }
        }

        return true;
    }
}
