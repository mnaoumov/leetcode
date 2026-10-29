namespace LeetCode.Problems._3356_Zero_Array_Transformation_II;

/// <summary>
/// https://leetcode.com/problems/zero-array-transformation-ii/submissions/1573040586/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        var n = nums.Length;
        var m = queries.Length;

        var low = 0;
        var high = m;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (IsMinZero(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low == m + 1 ? -1 : low;

        bool IsMinZero(int count)
        {
            var diffs = new int[n + 1];

            for (var i = 0; i < count; i++)
            {
                var query = queries[i];
                var l = query[0];
                var r = query[1];
                var val = query[2];
                diffs[l] += val;
                diffs[r + 1] -= val;
            }

            var prefixSum = 0;

            for (var i = 0; i < n; i++)
            {
                prefixSum += diffs[i];

                if (prefixSum < nums[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
