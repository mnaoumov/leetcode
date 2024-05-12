using JetBrains.Annotations;

namespace LeetCode.Problems._2426_Number_of_Pairs_Satisfying_Inequality;

/// <summary>
/// https://leetcode.com/submissions/detail/902679126/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long NumberOfPairs(int[] nums1, int[] nums2, int diff)
    {
        var n = nums1.Length;

        var diffs = new List<int>();

        var result = 0L;

        for (var i = 0; i < n; i++)
        {
            var currentDiff = nums1[i] - nums2[i];
            result += GetMaxInsertIndex(diffs, currentDiff + diff);
            diffs.Insert(GetMaxInsertIndex(diffs, currentDiff), currentDiff);
        }

        return result;
    }

    private static int GetMaxInsertIndex<T>(IReadOnlyList<T> list, T item) where T : IComparable<T>
    {
        var low = 0;
        var high = list.Count;

        while (low < high)
        {
            var mid = low + (high - low >> 1);

            var currentItem = list[mid];
            var comparisonResult = currentItem.CompareTo(item);

            if (comparisonResult <= 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}
