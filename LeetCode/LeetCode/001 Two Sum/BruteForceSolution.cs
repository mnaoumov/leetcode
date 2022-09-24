namespace LeetCode._001_Two_Sum;

public class BruteForceSolution : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] {i, j};
                }
            }
        }

        throw new InvalidOperationException();
    }
}