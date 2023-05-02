// ReSharper disable All
using JetBrains.Annotations;

namespace LeetCode._0718_Maximum_Length_of_Repeated_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/195833556/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindLength(int[] A, int[] B)
    {
        var suffixArrayLengths = new int[A.Length + 1, B.Length + 1];
        var max = 0;
        for (var j = B.Length - 1; j >= 0; j--)
        {
            for (var i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] != B[j])
                {
                    suffixArrayLengths[i, j] = 0;
                }
                else
                {
                    suffixArrayLengths[i, j] = suffixArrayLengths[i + 1, j + 1] + 1;
                    max = Math.Max(max, suffixArrayLengths[i, j]);
                }
            }
        }

        return max;
    }
}
