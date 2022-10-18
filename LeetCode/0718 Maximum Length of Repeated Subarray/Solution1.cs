// ReSharper disable All
#pragma warning disable
using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0718_Maximum_Length_of_Repeated_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/195796428/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLength(int[] A, int[] B)
    {
        var tailResults = new int?[A.Length, B.Length];
        return FindLength(A, B, 0, 0, tailResults);
    }

    private int FindLength(int[] A, int[] B, int indexA, int indexB, int?[,] tailResults)
    {
        if (indexA >= A.Length || indexB >= B.Length)
        {
            return 0;
        }

        if (tailResults[indexA, indexB] == null)
        {
            tailResults[indexA, indexB] = FindLengthImpl(A, B, indexA, indexB, tailResults);
        }

        return tailResults[indexA, indexB].Value;
    }

    private int FindLengthImpl(int[] A, int[] B, int indexA, int indexB, int?[,] tailResults)
    {
        var nextA = FindLength(A, B, indexA + 1, indexB, tailResults);
        var nextB = FindLength(A, B, indexA, indexB + 1, tailResults);
        var hasMatch = A[indexA] == B[indexB];
        return Math.Max(Math.Min(nextA, nextB) + (hasMatch ? 1 : 0), Math.Max(nextA, nextB));
    }
}
