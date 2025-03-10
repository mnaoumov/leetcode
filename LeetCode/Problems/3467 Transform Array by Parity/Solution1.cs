namespace LeetCode.Problems._3467_Transform_Array_by_Parity;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-151/problems/transform-array-by-parity/submissions/1559234912/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] TransformArray(int[] nums)
    {
        var ans = new int[nums.Length];
        var oddsCount = nums.Count(num => num % 2 == 1);

        for (var i = ans.Length - 1; i >= ans.Length - oddsCount; i--)
        {
            ans[i] = 1;
        }

        return ans;
    }
}
