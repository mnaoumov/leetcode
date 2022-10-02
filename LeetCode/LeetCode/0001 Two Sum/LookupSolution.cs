namespace LeetCode._0001_Two_Sum;

public class LookupSolution : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var sortedCopy = nums.OrderBy(x => x).ToArray();

        for (int i = 0; i < nums.Length; i++)
        {
            var secondAddendum = target - nums[i];
            var secondAddendumIndex = Array.BinarySearch(sortedCopy, i + 1, nums.Length - i - 1, secondAddendum);
            if (secondAddendumIndex > 0)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == secondAddendum)
                    {
                        return new[] {i, j};
                    }
                }

            }
        }

        throw new InvalidOperationException();
    }
}