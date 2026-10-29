namespace LeetCode.Problems._1526_Minimum_Number_of_Increments_on_Subarrays_to_Form_a_Target_Array;

/// <summary>
/// https://leetcode.com/problems/minimum-number-of-increments-on-subarrays-to-form-a-target-array/submissions/1816413992/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinNumberOperations(int[] target)
    {
        var ans = target[0];

        for (var i = 1; i < target.Length; i++)
        {
            ans += Math.Max(target[i] - target[i - 1], 0);
        }

        return ans;
    }
}
