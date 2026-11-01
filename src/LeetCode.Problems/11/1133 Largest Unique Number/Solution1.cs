namespace LeetCode.Problems._1133_Largest_Unique_Number;

/// <seealso href="https://leetcode.com/submissions/detail/856497433/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestUniqueNumber(int[] nums) =>
        nums
            .GroupBy(num => num)
            .Select(g => (num: g.Key, count: g.Count()))
            .Where(x => x.count == 1)
            .Select(x => x.num)
            .DefaultIfEmpty(-1)
            .Max();
}
