namespace LeetCode.Problems._2449_Minimum_Number_of_Operations_to_Make_Arrays_Similar;

/// <summary>
/// https://leetcode.com/submissions/detail/828407147/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MakeSimilar(int[] nums, int[] target)
    {
        Array.Sort(nums);
        Array.Sort(target);

        return CalculateForRemainder(0) + CalculateForRemainder(1);


        long CalculateForRemainder(int remainder) => Calculate(nums.Where(x => x % 2 == remainder).ToArray(),
            target.Where(x => x % 2 == remainder).ToArray());
    }

    private static long Calculate(IReadOnlyList<int> nums, IReadOnlyList<int> target)
    {
        long result = 0;

        for (var i = 0; i < nums.Count; i++)
        {
            if (target[i] > nums[i])
            {
                result += (long) Math.Ceiling((double) (target[i] - nums[i]) / 2);
            }
        }

        return result;
    }
}
