namespace LeetCode.Problems._3346_Maximum_Frequency_of_an_Element_After_Performing_Operations_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-143/submissions/detail/1447773074/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        Array.Sort(nums);
        var n = nums.Length;
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            if (i > 0 && num == nums[i - 1])
            {
                continue;
            }

            var lastIndexSameValue = BinarySearchLast(nums, num, i);

            var lastIndex = BinarySearchLast(nums, num + k, lastIndexSameValue + 1);
            var firstIndex = BinarySearchFirst(nums, num - k, 0, i - 1);
            ans = Math.Max(ans,
                lastIndexSameValue - i + 1 + Math.Min(numOperations, lastIndex - lastIndexSameValue + i - firstIndex));

            if (i == n - 1 || nums[i + 1] == num + 1)
            {
                continue;
            }

            var mid = num + nums[i + 1] >> 1;
            ans = Math.Max(ans,
                Math.Min(numOperations,
                    1 +
                    BinarySearchLast(nums, mid + k, i + 1) -
                    BinarySearchFirst(nums, mid - k, 0, i)));
        }

        return ans;
    }

    private static int BinarySearchFirst<T>(IReadOnlyList<T> arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Count - 1;

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

    private static int BinarySearchLast<T>(IReadOnlyList<T> arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Count - 1;

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
