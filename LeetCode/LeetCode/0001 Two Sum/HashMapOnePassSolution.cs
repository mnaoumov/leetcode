namespace LeetCode._0001_Two_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/804827752/
/// </summary>
public class HashMapOnePassSolution : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
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