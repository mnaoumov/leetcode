namespace LeetCode.Problems._2145_Count_the_Hidden_Sequences;

/// <summary>
/// https://leetcode.com/problems/count-the-hidden-sequences/submissions/1612992343/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        var min = 0L;
        var max = 0L;
        var sum = 0L;

        foreach (var difference in differences)
        {
            sum += difference;
            min = Math.Min(min, sum);
            max = Math.Max(max, sum);
        }

        return (int) Math.Max(0, upper - lower - max + min + 1);
    }
}
