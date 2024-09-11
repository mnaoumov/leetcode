namespace LeetCode.Problems._3072_Distribute_Elements_Into_Two_Arrays_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-387/submissions/detail/1192222883/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ResultArray(int[] nums)
    {
        var arr1 = new List<int> { nums[0] };
        var arr2 = new List<int> { nums[1] };

        var arr1Sorted = new List<int> { nums[0] };
        var arr2Sorted = new List<int> { nums[1] };

        for (var i = 2; i < nums.Length; i++)
        {
            var num = nums[i];

            var insertionIndex1 = GetInsertionIndex(num, arr1Sorted);
            var insertionIndex2 = GetInsertionIndex(num, arr2Sorted);

            var greaterCount1 = arr1Sorted.Count - insertionIndex1;
            var greaterCount2 = arr2Sorted.Count - insertionIndex2;

            bool shouldAddToArr1;

            if (greaterCount1 > greaterCount2)
            {
                shouldAddToArr1 = true;
            }
            else if (greaterCount1 < greaterCount2)
            {
                shouldAddToArr1 = false;
            }
            else if (arr1Sorted.Count <= arr2Sorted.Count)
            {
                shouldAddToArr1 = true;
            }
            else
            {
                shouldAddToArr1 = false;
            }

            if (shouldAddToArr1)
            {
                arr1.Add(num);
                arr1Sorted.Insert(insertionIndex1, num);
            }
            else
            {
                arr2.Add(num);
                arr2Sorted.Insert(insertionIndex2, num);
            }
        }


        return arr1.Concat(arr2).ToArray();
    }

    private static int GetInsertionIndex(int num, IReadOnlyList<int> sortedList)
    {
        var low = 0;
        var high = sortedList.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (sortedList[mid] <= num)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;
    }
}
