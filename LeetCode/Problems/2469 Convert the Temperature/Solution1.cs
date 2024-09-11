namespace LeetCode.Problems._2469_Convert_the_Temperature;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-319/submissions/detail/842330859/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double[] ConvertTemperature(double celsius) => new[] { celsius + 273.15, celsius * 1.80 + 32.00 };
}
