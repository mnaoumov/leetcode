using JetBrains.Annotations;

namespace LeetCode.Problems._2708_Maximum_Strength_of_a_Group;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-105/submissions/detail/958362941/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxStrength(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var negatives = nums.Where(num => num < 0).OrderBy(num => num).ToArray();
        var evenCountNegatives = negatives.Take(negatives.Length / 2 * 2).ToArray();
        var positives = nums.Where(num => num > 0).ToArray();

        return positives.Length > 0 || evenCountNegatives.Length > 0
            ? Product(positives) * Product(evenCountNegatives)
            : 0;
    }

    private static long Product(IEnumerable<int> arr) => arr.Aggregate(1L, (product, value) => product * value);
}
