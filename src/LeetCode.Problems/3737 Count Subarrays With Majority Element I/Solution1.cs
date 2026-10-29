namespace LeetCode.Problems._3737_Count_Subarrays_With_Majority_Element_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-169/problems/count-subarrays-with-majority-element-i/submissions/1824144384/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountMajoritySubarrays(int[] nums, int target)
    {
        var n = nums.Length;
        var targetCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            targetCounts[i + 1] = targetCounts[i] + (nums[i] == target ? 1 : 0);
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                var length = j - i + 1;
                var targetCount = targetCounts[j + 1] - targetCounts[i];

                if (targetCount > length / 2)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
