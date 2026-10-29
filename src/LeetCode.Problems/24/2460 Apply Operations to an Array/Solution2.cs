namespace LeetCode.Problems._2460_Apply_Operations_to_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-318/submissions/detail/837722048/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] ApplyOperations(int[] nums)
    {
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] != nums[i + 1])
            {
                continue;
            }

            nums[i] *= 2;
            nums[i + 1] = 0;
        }

        var result = new int[nums.Length];
        var index = 0;

        foreach (var num in nums)
        {
            if (num == 0)
            {
                continue;
            }

            result[index] = num;
            index++;
        }

        return result;
    }
}
