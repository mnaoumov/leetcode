namespace LeetCode.Problems._2270_Number_of_Ways_to_Split_Array;

/// <seealso href="https://leetcode.com/submissions/detail/855797797/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int WaysToSplitArray(int[] nums)
    {
        var sum = nums.Sum(x => (long) x);
        var half = Math.Ceiling(sum / 2.0);
        var runningSum = 0L;
        var result = 0;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            runningSum += nums[i];

            if (runningSum >= half)
            {
                result++;
            }
        }

        return result;
    }
}
