using JetBrains.Annotations;

namespace LeetCode.Problems._1588_Sum_of_All_Odd_Length_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/926807890/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOddLengthSubarrays(int[] arr)
    {
        var n = arr.Length;
        var multiplier = (n + 1) / 2;

        var sum = 0;

        for (var i = 0; i < n; i++)
        {
            sum += multiplier * arr[i];
            multiplier += (n - i) / 2 - i / 2 - 1;
        }

        return sum;
    }
}
