// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class BinarySearchTemplate
{
    /// <summary>
    /// The index of the first element &gt;= <paramref name="value"/> in the sorted range; <c>lastIndex + 1</c> (by default <c>Count</c>) when there is none.
    /// </summary>
    public static int BinarySearchFirst<T>(IReadOnlyList<T> arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Count - 1;

        while (low <= high)
        {
            var mid = low + ((high - low) >> 1);

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

    /// <summary>
    /// The index of the last element &lt;= <paramref name="value"/> in the sorted range; <c>firstIndex - 1</c> (by default <c>-1</c>) when there is none.
    /// </summary>
    public static int BinarySearchLast<T>(IReadOnlyList<T> arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Count - 1;

        while (low <= high)
        {
            var mid = low + ((high - low) >> 1);

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
