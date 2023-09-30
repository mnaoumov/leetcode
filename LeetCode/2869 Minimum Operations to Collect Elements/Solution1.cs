using JetBrains.Annotations;

namespace LeetCode._2869_Minimum_Operations_to_Collect_Elements;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-114/submissions/detail/1063102504/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(IList<int> nums, int k)
    {
        var set = new HashSet<int>();

        for (var i = nums.Count - 1; i >= 0; i--)
        {
            var num = nums[i];

            if (num > k)
            {
                continue;
            }

            set.Add(num);

            if (set.Count == k)
            {
                return nums.Count - i;
            }
        }

        throw new InvalidOperationException();
    }
}
