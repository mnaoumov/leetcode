namespace LeetCode.Problems._2091_Removing_Minimum_and_Maximum_From_Array;

/// <summary>
/// https://leetcode.com/problems/removing-minimum-and-maximum-from-array/submissions/2124647509/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDeletions(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 1;
        }

        var index1 = nums.IndexOf(nums.Min());
        var index2 = nums.IndexOf(nums.Max());

        if (index1 > index2)
        {
            (index1, index2) = (index2, index1);
        }

        return new[]
        {
            index2 + 1,
            nums.Length - index1,
            index1 + 1 + nums.Length - index2
        }.Min();
    }
}
