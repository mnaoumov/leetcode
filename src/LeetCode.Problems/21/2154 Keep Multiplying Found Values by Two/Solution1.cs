namespace LeetCode.Problems._2154_Keep_Multiplying_Found_Values_by_Two;

/// <summary>
/// https://leetcode.com/problems/keep-multiplying-found-values-by-two/submissions/1833719434/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindFinalValue(int[] nums, int original)
    {
        var set = nums.ToHashSet();

        while (set.Contains(original))
        {
            original *= 2;
        }

        return original;
    }
}
