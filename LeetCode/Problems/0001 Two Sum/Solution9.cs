using JetBrains.Annotations;

namespace LeetCode.Problems._0001_Two_Sum;

/// <summary>
/// Hashmap one pass
/// https://leetcode.com/submissions/detail/828902207/
/// </summary>
[UsedImplicitly]
public class Solution9 : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashMap = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var secondAddendum = target - nums[i];

            if (hashMap.TryGetValue(secondAddendum, out var secondAddendumIndex))
            {
                return new[] { secondAddendumIndex, i };
            }

            hashMap[nums[i]] = i;
        }

        throw new InvalidOperationException();
    }
}
