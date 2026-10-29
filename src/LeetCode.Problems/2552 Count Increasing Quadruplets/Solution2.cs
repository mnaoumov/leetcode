namespace LeetCode.Problems._2552_Count_Increasing_Quadruplets;

/// <summary>
/// https://leetcode.com/submissions/detail/887542502/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long CountQuadruplets(int[] nums)
    {
        var n = nums.Length;
        var iCounts = new int[n, n];
        var lCounts = new int[n, n];

        var result = 0L;

        for (var k = n - 2; k >= 0; k--)
        {
            for (var j = 0; j < k; j++)
            {
                lCounts[j, k] = lCounts[j, k + 1] + (nums[k + 1] > nums[j] ? 1 : 0);
            }
        }

        for (var j = 1; j < n - 1; j++)
        {
            for (var k = j + 1; k < n - 1; k++)
            {
                iCounts[j, k] = iCounts[j - 1, k] + (nums[k] > nums[j - 1] ? 1 : 0);

                if (nums[k] < nums[j])
                {
                    result += iCounts[j, k] * lCounts[j, k];
                }
            }
        }

        return result;
    }
}
