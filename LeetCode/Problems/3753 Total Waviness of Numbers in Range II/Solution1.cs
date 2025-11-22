namespace LeetCode.Problems._3753_Total_Waviness_of_Numbers_in_Range_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long TotalWaviness(long num1, long num2) => TotalWaviness(num2) - TotalWaviness(num1 - 1);

    private static long TotalWaviness(long max)
    {
        return 0;
    }
}
