using JetBrains.Annotations;

namespace LeetCode.Problems._1885_Count_Pairs_in_Two_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1246991058/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountPairs(int[] nums1, int[] nums2)
    {
        var ans = 0L;

        var n = nums1.Length;
        var orderedDiffs = new List<int>();

        for (var j = 0; j < n; j++)
        {
            var diff = nums1[j] - nums2[j];

            var negativeDiffIndex = FindFirstIndex(orderedDiffs, -diff + 1);

            ans += orderedDiffs.Count - negativeDiffIndex;
            InsertInOrderedList(orderedDiffs, diff);
        }

        return ans;
    }

    private static int FindFirstIndex<T>(IReadOnlyList<T> list, T target) where T : IComparable<T>
    {
        var low = 0;
        var high = list.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            var value = list[mid];

            if (value.CompareTo(target) >= 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private static void InsertInOrderedList<T>(List<T> list, T item)
    {
        var index = list.BinarySearch(item);

        if (index < 0)
        {
            index = ~index;
        }

        list.Insert(index, item);
    }
}
