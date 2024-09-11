namespace LeetCode.Problems._2294_Partition_Array_Such_That_Maximum_Difference_Is_K;

/// <summary>
/// https://leetcode.com/submissions/detail/914069640/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PartitionArray(int[] nums, int k)
    {
        Array.Sort(nums);

        var result = 0;
        var min = int.MinValue;

        foreach (var num in nums)
        {
            if (num <= min + k)
            {
                continue;
            }

            result++;
            min = num;
        }

        return result;
    }
}
