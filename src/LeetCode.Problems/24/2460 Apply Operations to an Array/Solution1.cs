namespace LeetCode.Problems._2460_Apply_Operations_to_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-318/submissions/detail/837717271/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] ApplyOperations(int[] nums)
    {
        var result = new int[nums.Length];
        var index = 0;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == 0)
            {
                continue;
            }

            if (nums[i] == nums[i + 1])
            {
                result[index] = nums[i] * 2;
                i++;
            }
            else
            {
                result[index] = nums[i];
            }
            index++;
        }

        result[index] = nums[^1];

        return result;
    }
}
