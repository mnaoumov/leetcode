namespace LeetCode._0001_Two_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/804724157/
/// </summary>
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
            var secondAddendum = target - nums[i];

            if (hashMap.TryGetValue(secondAddendum, out var secondAddendumIndex) && secondAddendumIndex > i)
            {
                return new[] { i, secondAddendumIndex };
            }
        }

        throw new InvalidOperationException();
    }
}