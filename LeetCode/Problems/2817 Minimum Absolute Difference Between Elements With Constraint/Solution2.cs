using JetBrains.Annotations;

namespace LeetCode.Problems._2817_Minimum_Absolute_Difference_Between_Elements_With_Constraint;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-358/submissions/detail/1019778220/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinAbsoluteDifference(IList<int> nums, int x)
    {
        var n = nums.Count;

        var leftValues = new List<int>();
        var ans = int.MaxValue;

        for (var i = 0; i < n - x; i++)
        {
            var leftValue = nums[i];
            var index = leftValues.BinarySearch(nums[i]);

            if (index < 0)
            {
                index = ~index;
            }

            leftValues.Insert(index, leftValue);

            var rightValue = nums[i + x];
            index = leftValues.BinarySearch(rightValue);

            if (index >= 0)
            {
                return 0;
            }

            index = ~index;

            if (index < leftValues.Count)
            {
                ans = Math.Min(ans, leftValues[index] - rightValue);
            }

            if (index > 0)
            {
                ans = Math.Min(ans, rightValue - leftValues[index - 1]);
            }
        }

        return ans;
    }
}
