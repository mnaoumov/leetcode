using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._1498_Number_of_Subsequences_That_Satisfy_the_Given_Sum_Condition;

/// <summary>
/// https://leetcode.com/submissions/detail/945270115/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSubseq(int[] nums, int target)
    {
        Array.Sort(nums);
        const int modulo = 1_000_000_007;

        var n = nums.Length;
        var ans = 0;

        for (var minIndex = 0; minIndex < n; minIndex++)
        {
            var min = nums[minIndex];
            var max = target - min;

            if (min > max)
            {
                break;
            }

            var bs = new BinarySearch<int>(nums);
            var maxIndex = bs.FindIndexOfTheLastItemBefore(max);
            ans = (int) ((ans + BigInteger.ModPow(2, maxIndex - minIndex, modulo)) % modulo);
        }

        return ans;
    }

    private class BinarySearch<T> where T : IComparable<T>
    {
        private readonly IReadOnlyList<T> _sortedList;

        public BinarySearch(IReadOnlyList<T> sortedList)
        {
            _sortedList = sortedList;
        }

        public int FindIndexOfTheLastItemBefore(T target)
        {
            var low = 0;
            var high = _sortedList.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                var cmp = _sortedList[mid].CompareTo(target);

                if (cmp > 0)
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
