namespace LeetCode.Problems._3739_Count_Subarrays_With_Majority_Element_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-169/problems/count-subarrays-with-majority-element-ii/submissions/1824274302/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        var targetCount = 0;
        var ans = 0L;
        var set = new SortedSet<(int weight, int index)>
        {
            (0, -1)
        };

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num == target)
            {
                targetCount++;
            }

            var weight = 2 * targetCount - i - 1;
            set.Add((weight, i));

            var subset = set.GetViewBetween((int.MinValue, 0), (weight - 1, i));
            ans += subset.Count;
        }

        return ans;

    }
}
