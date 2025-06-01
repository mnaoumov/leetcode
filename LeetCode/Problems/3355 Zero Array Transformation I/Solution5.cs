namespace LeetCode.Problems._3355_Zero_Array_Transformation_I;

/// <summary>
/// https://leetcode.com/problems/zero-array-transformation-i/submissions/1638841518/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        var n = nums.Length;
        var deltas = new int[n + 1];

        foreach (var query in queries)
        {
            var l = query[0];
            var r = query[1];
            deltas[l]++;
            deltas[r + 1]--;
        }

        var prefixSums = new int[n + 1];
        for (var i = 0; i <= n; i++)
        {
            prefixSums[i] = (i == 0 ? 0 : prefixSums[i - 1]) + deltas[i];
        }

        for (var i = 0; i < n; i++)
        {
            if (prefixSums[i] < nums[i])
            {
                return false;
            }
        }

        return true;
    }
}
