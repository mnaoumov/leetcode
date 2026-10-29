namespace LeetCode.Problems._1846_Maximum_Element_After_Decreasing_and_Rearranging;

/// <summary>
/// https://leetcode.com/submissions/detail/1099021696/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        var sorted = arr.OrderBy(num => num).ToArray();
        sorted[0] = 1;

        for (var i = 1; i < sorted.Length; i++)
        {
            sorted[i] = Math.Min(sorted[i], sorted[i - 1] + 1);
        }

        return sorted[^1];
    }
}
