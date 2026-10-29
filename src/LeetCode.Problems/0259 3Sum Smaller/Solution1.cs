namespace LeetCode.Problems._0259_3Sum_Smaller;

/// <summary>
/// https://leetcode.com/problems/3sum-smaller/submissions/1830006645/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int ThreeSumSmaller(int[] nums, int target)
    {
        var n = nums.Length;
        var ans = 0;

        var set = new SortedSet<(int num, int index)>();

        for (var j = n - 1; j >= 0; j--)
        {
            for (var i = j - 1; i >= 0; i--)
            {
                var maxNum = target - nums[i] - nums[j];
                ans += set.GetViewBetween((int.MinValue, 0), (maxNum, -1)).Count;
            }

            set.Add((nums[j], j));
        }

        return ans;
    }
}
