namespace LeetCode._001_Two_Sum;

public class LookupSolution : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var sortedCopy = nums.OrderBy(x => x).ToArray();

        for (int i = 0; i < nums.Length; i++)
        {
            var secondSummand = target - nums[i];
            var secondSummandIndex = Array.BinarySearch(sortedCopy, i + 1, nums.Length - i - 1, secondSummand);
            if (secondSummandIndex > 0)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == secondSummand)
                    {
                        return new[] {i, j};
                    }
                }

            }
        }

        return null;
    }
}