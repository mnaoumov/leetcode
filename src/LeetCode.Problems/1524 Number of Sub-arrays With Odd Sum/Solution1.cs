namespace LeetCode.Problems._1524_Number_of_Sub_arrays_With_Odd_Sum;

/// <summary>
/// https://leetcode.com/problems/number-of-sub-arrays-with-odd-sum/submissions/1554380380/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumOfSubarrays(int[] arr)
    {
        var prefixSumParity = 0;
        var evenPrefixSumsCount = 1;

        var ans = 0;
        const int modulus = 1_000_000_007;

        var index = 0;

        foreach (var num in arr)
        {
            var nextPrefixSumParity = prefixSumParity + num & 1;

            if (nextPrefixSumParity == 0)
            {
                ans = (ans + index + 1 - evenPrefixSumsCount) % modulus;
                evenPrefixSumsCount++;
            }
            else
            {
                ans = (ans + evenPrefixSumsCount) % modulus;
            }

            prefixSumParity = nextPrefixSumParity;
            index++;
        }

        return ans;
    }
}
