namespace LeetCode.Problems._0217_Contains_Duplicate;

/// <seealso href="https://leetcode.com/submissions/detail/898935842/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();
        return nums.Any(num => !set.Add(num));
    }
}
