namespace LeetCode.Problems._2145_Count_the_Hidden_Sequences;

/// <summary>
/// https://leetcode.com/problems/count-the-hidden-sequences/submissions/1612991269/?envType=daily-question&envId=2025-04-21
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        var min = 0;
        var max = 0;
        var sum = 0;

        foreach (var difference in differences)
        {
            sum += difference;
            min = Math.Min(min, sum);
            max = Math.Max(max, sum);
        }

        return Math.Max(0, upper - lower - max + min + 1);
    }
}
