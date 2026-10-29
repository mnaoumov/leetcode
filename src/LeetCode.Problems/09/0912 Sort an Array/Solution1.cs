namespace LeetCode.Problems._0912_Sort_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/906825403/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SortArray(int[] nums)
    {
        MergeSort(nums, 0, nums.Length);
        return nums;
    }

    private static void MergeSort(IList<int> arr, int from, int to)
    {
        if (to - from == 1)
        {
            return;
        }

        var mid = from + (to - from >> 1);
        MergeSort(arr, from, mid);
        MergeSort(arr, mid, to);

        var temp = new int[to - from];

        var index1 = from;
        var index2 = mid;
        var index = 0;

        while (index1 < mid || index2 < to)
        {
            int value;

            if (index2 == to || index1 < mid && arr[index1] < arr[index2])
            {
                value = arr[index1];
                index1++;
            }
            else
            {
                value = arr[index2];
                index2++;
            }

            temp[index] = value;
            index++;
        }

        for (var i = from; i < to; i++)
        {
            arr[i] = temp[i - from];
        }
    }
}
