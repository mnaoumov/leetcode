namespace LeetCode.Problems._1848_Minimum_Distance_to_the_Target_Element;

/// <summary>
/// https://leetcode.com/problems/minimum-distance-to-the-target-element/submissions/1976840434/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        var ans = 0;

        while (true)
        {
            var index1 = start - ans;
            var index2 = start + ans;

            if (
                (index1 >= 0 && nums[index1] == target)
                || (ans > 0 && index2 < nums.Length && nums[index2] == target)
                )
            {
                return ans;
            }

            ans++;
        }
    }
}
