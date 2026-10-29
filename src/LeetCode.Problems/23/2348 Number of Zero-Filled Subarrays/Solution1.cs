namespace LeetCode.Problems._2348_Number_of_Zero_Filled_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/919158455/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        var result = 0L;
        var zeroSequenceLength = 0;

        foreach (var num in nums)
        {
            if (num == 0)
            {
                zeroSequenceLength++;
                result += zeroSequenceLength;
            }
            else
            {
                zeroSequenceLength = 0;
            }
        }

        return result;
    }
}
