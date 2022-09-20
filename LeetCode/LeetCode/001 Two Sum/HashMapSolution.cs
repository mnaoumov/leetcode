namespace LeetCode._001_Two_Sum;

public class HashMapSolution : ISolution
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