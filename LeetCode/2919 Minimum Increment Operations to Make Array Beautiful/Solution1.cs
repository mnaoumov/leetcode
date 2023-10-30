using JetBrains.Annotations;

namespace LeetCode._2919_Minimum_Increment_Operations_to_Make_Array_Beautiful;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-369/submissions/detail/1086482671/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinIncrementOperations(int[] nums, int k)
    {
        var n = nums.Length;
        var ans = 0L;

        for (var i = 0; i < n - 2; i++)
        {
            var max = nums[i];
            var maxIndex = i;

            for (var j = i + 1; j < i + 3; j++)
            {
                if (nums[j] < max)
                {
                    continue;
                }

                max = nums[j];
                maxIndex = j;
            }

            if (max >= k)
            {
                continue;
            }

            ans += k - max;
            nums[maxIndex] = k;
        }

        return ans;
    }
}
