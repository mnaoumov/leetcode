namespace LeetCode.Problems._0275_H_Index_II;

/// <summary>
/// https://leetcode.com/submissions/detail/934913281/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int HIndex(int[] citations)
    {
        var n = citations.Length;
        var low = 0;
        var high = Math.Min(1000, n);

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (mid == 0 || citations[n - mid] >= mid)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;
    }
}
