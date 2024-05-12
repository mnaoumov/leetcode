using JetBrains.Annotations;

namespace LeetCode._1574_Shortest_Subarray_to_be_Removed_to_Make_Array_Sorted;

/// <summary>
/// https://leetcode.com/submissions/detail/950474972/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLengthOfShortestSubarray(int[] arr)
    {
        var prefixes = new List<int>();
        var suffixes = new List<int>();

        foreach (var num in arr)
        {
            if (prefixes.Count > 0 && prefixes[^1] > num)
            {
                break;
            }

            prefixes.Add(num);
        }

        foreach (var num in arr.Reverse())
        {
            if (suffixes.Count > 0 && suffixes[^1] < num)
            {
                break;
            }

            suffixes.Add(num);
        }

        suffixes.Reverse();

        var n = arr.Length;

        var ans = n - suffixes.Count;

        for (var i = 0; i < prefixes.Count; i++)
        {
            var prefix = prefixes[i];
            var low = 0;
            var high = suffixes.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (suffixes[mid] < prefix)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            var j = low + n - suffixes.Count;

            if (j > i)
            {
                ans = Math.Min(ans, j - i - 1);
            }
        }

        return ans;
    }
}
