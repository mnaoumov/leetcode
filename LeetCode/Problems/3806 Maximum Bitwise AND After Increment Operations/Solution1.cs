namespace LeetCode.Problems._3806_Maximum_Bitwise_AND_After_Increment_Operations;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int MaximumAND(int[] nums, int k, int m)
    {
        nums = nums.OrderByDescending(num => num).ToArray();
        var and = nums.Take(m).Aggregate((a, b) => a & b);



        throw new NotImplementedException();
    }
}
