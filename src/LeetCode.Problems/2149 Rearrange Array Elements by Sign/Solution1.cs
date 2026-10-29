namespace LeetCode.Problems._2149_Rearrange_Array_Elements_by_Sign;

/// <summary>
/// https://leetcode.com/submissions/detail/1174662113/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] RearrangeArray(int[] nums)
    {
        var positives = nums.Where(num => num > 0);
        var negatives = nums.Where(num => num < 0);
        return positives
            .Zip(negatives, (positive, negative) => new[] { positive, negative })
            .SelectMany(num => num)
            .ToArray();
    }
}
