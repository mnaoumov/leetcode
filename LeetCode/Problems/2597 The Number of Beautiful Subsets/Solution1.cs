using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2597_The_Number_of_Beautiful_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/918926972/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int BeautifulSubsets(int[] nums, int k)
    {
        Array.Sort(nums);
        var result = 0;
        var counts = new Dictionary<int, int>();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i == nums.Length)
            {
                return;
            }

            result++;

            for (var j = i; j < nums.Length; j++)
            {
                var num = nums[i];

                if (counts.GetValueOrDefault(num - k) > 0)
                {
                    continue;
                }

                counts[num] = counts.GetValueOrDefault(num) + 1;
                Backtrack(i + 1);
                counts[num]--;
            }
        }
    }
}
