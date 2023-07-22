using JetBrains.Annotations;

namespace LeetCode._2780_Minimum_Index_of_a_Valid_Split;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-354/submissions/detail/995530902/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumIndex(IList<int> nums)
    {
        var (x, totalCount) = nums.GroupBy(num => num).Select(g => (num: g.Key, count: g.Count())).MaxBy(y => y.count);

        var count = 0;

        var n = nums.Count;

        for (var i = 0; i < n - 1; i++)
        {
            if (nums[i] == x)
            {
                count++;
            }

            if (2 * count > i + 1 && 2 * (totalCount - count) > n - 1 - i)
            {
                return i;
            }
        }

        return -1;
    }
}
