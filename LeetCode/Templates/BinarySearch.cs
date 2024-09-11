// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates
{
    public static class BinarySearch
    {
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
}
