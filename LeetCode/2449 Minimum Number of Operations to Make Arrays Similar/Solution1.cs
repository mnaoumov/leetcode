using JetBrains.Annotations;

namespace LeetCode._2449_Minimum_Number_of_Operations_to_Make_Arrays_Similar;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-316/submissions/detail/828356194/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MakeSimilar(int[] nums, int[] target)
    {
        Array.Sort(nums);
        Array.Sort(target);

        long result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (target[i] > nums[i])
            {
                result += (long)Math.Ceiling((double)(target[i] - nums[i]) / 2);
            }
        }

        return result;
    }
}