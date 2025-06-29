namespace LeetCode.Problems._2040_Kth_Smallest_Product_of_Two_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/problems/kth-smallest-product-of-two-sorted-arrays/submissions/1675512605/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
    {
        const long impossible = long.MaxValue;

        var min1 = nums1.Min();
        var max1 = nums1.Max();
        var min2 = nums2.Min();
        var max2 = nums2.Max();
        var boundaryProducts = new[] { 1L * min1 * min2, 1L * min1 * max2, 1L * max1 * min2, 1L * max1 * max2 };
        var minProduct = boundaryProducts.Min();
        var maxProduct = boundaryProducts.Max();

        return BinarySearch(minProduct, maxProduct);

        long BinarySearch(long low, long high)
        {
            if (low > high)
            {
                return IsValidProduct(low) ? low : impossible;
            }

            var mid = low + (high - low) / 2;

            var notGreaterProductCount = 0L;

            foreach (var num1 in nums1)
            {
                switch (num1)
                {
                    case 0:
                        {
                            if (mid >= 0)
                            {
                                notGreaterProductCount += nums2.Length;
                            }

                            break;
                        }
                    case > 0:
                        {
                            var boundary2 = mid / num1;

                            if (boundary2 < nums2[0])
                            {
                            }
                            else if (boundary2 > nums2[^1])
                            {
                                notGreaterProductCount += nums2.Length;
                            }
                            else
                            {
                                notGreaterProductCount += 1 + BinarySearchFirst(nums2, (int) boundary2);
                            }

                            break;
                        }
                    default:
                        {
                            var boundary2 = (long) Math.Ceiling((double) mid / num1);

                            if (boundary2 < nums2[0])
                            {
                                notGreaterProductCount += nums2.Length;
                            }
                            else if (boundary2 > nums2[^1])
                            {
                            }
                            else
                            {
                                notGreaterProductCount += nums2.Length - BinarySearchLast(nums2, (int) boundary2);
                            }

                            break;
                        }
                }

                if (notGreaterProductCount > k)
                {
                    break;
                }
            }

            if (notGreaterProductCount < k)
            {
                return BinarySearch(mid + 1, high);
            }

            if (notGreaterProductCount > k)
            {
                return BinarySearch(low, mid - 1);
            }

            if (IsValidProduct(mid))
            {
                return mid;
            }

            var lowPartResult = BinarySearch(low, mid - 1);

            if (lowPartResult != impossible)
            {
                return lowPartResult;
            }

            return BinarySearch(mid + 1, high);
        }

        bool IsValidProduct(long mid)
        {
            foreach (var num1 in nums1)
            {
                if (num1 == 0)
                {
                    if (mid != 0)
                    {
                        continue;
                    }

                    return true;
                }

                if (mid % num1 != 0)
                {
                    continue;
                }

                var num2 = mid / num1;

                if (num2 < nums2[0] || num2 > nums2[^1])
                {
                    continue;
                }

                if (Array.BinarySearch(nums2, (int) num2) >= 0)
                {
                    return true;
                }
            }

            return false;
        }
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
