namespace LeetCode.Problems._2779_Maximum_Beauty_of_an_Array_After_Applying_Operation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-354/submissions/detail/995496752/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);

        var ans = 0;
        var max = int.MinValue;
        var length = 0;

        foreach (var num in nums)
        {
            if (num <= max)
            {
                length++;
                ans = Math.Max(ans, length);
            }
            else
            {
                length = 1;
                max = num + 2 * k;
            }
        }

        return ans;
    }
}
