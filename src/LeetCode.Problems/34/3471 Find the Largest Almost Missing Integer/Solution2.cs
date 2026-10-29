namespace LeetCode.Problems._3471_Find_the_Largest_Almost_Missing_Integer;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-439/problems/find-the-largest-almost-missing-integer/submissions/1559828524/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LargestInteger(int[] nums, int k)
    {
        const int missing = -1;

        if (k == 1)
        {
            return nums.GroupBy(num => num).Where(g => g.Count() == 1).SelectMany(num => num).DefaultIfEmpty(missing).Max();
        }

        if (nums.Length == k)
        {
            return nums.Max();
        }

        if (nums[0] == nums[^1])
        {
            return missing;
        }

        var rest = nums.Skip(1).Take(nums.Length - 2).ToHashSet();

        var max = Math.Max(nums[0], nums[^1]);

        if (!rest.Contains(max))
        {
            return max;
        }

        var min = Math.Min(nums[0], nums[^1]);
        return !rest.Contains(min) ? min : missing;
    }
}
