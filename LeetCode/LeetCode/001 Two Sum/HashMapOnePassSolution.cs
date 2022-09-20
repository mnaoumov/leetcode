namespace LeetCode._001_Two_Sum;

public class HashMapOnePassSolution : ISolution
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