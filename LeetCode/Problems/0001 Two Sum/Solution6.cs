#pragma warning disable

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0001_Two_Sum;

/// <summary>
/// Hashmap one pass
/// https://leetcode.com/submissions/detail/804827752/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var secondSummand = target - nums[i];

            if (hashMap.TryGetValue(secondSummand, out var secondSummandIndex))
            {
                return new[] { secondSummandIndex, i };
            }

            hashMap[nums[i]] = i;
        }

        return null;
    }
}
