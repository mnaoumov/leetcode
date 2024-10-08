#pragma warning disable

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0001_Two_Sum;

/// <summary>
/// Hash map
/// https://leetcode.com/submissions/detail/804724157/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashMap = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            hashMap[nums[i]] = i;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var secondSummand = target - nums[i];

            if (hashMap.TryGetValue(secondSummand, out var secondSummandIndex) && secondSummandIndex > i)
            {
                return new[] { i, secondSummandIndex };
            }
        }

        return null;
    }
}
