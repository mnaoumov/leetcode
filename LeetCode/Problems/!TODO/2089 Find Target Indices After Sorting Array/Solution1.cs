namespace LeetCode.Problems._2089_Find_Target_Indices_After_Sorting_Array;

/// <summary>
/// https://leetcode.com/problems/find-target-indices-after-sorting-array/submissions/2175827102/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> TargetIndices(int[] nums, int target)
    {
        Array.Sort(nums);

        var firstIndex = BinarySearchFirst(nums, target);

        if (firstIndex < 0 || firstIndex >= nums.Length)
        {
            return Array.Empty<int>();
        }

        var lastIndex = BinarySearchLast(nums, target);
        return Enumerable.Range(firstIndex, lastIndex - firstIndex + 1).ToArray();
    }

    private static int BinarySearchFirst<T>(int[] arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid].CompareTo(value) >= 0)
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

    private static int BinarySearchLast<T>(int[] arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid].CompareTo(value) > 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return high;
    }
}
