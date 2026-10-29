namespace LeetCode.Problems._3899_Angles_of_a_Triangle;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-497/problems/angles-of-a-triangle/submissions/1975918039/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public double[] InternalAngles(int[] sides)
    {
        var p = sides.Sum() / 2;
        var max = sides.Max();

        if (p <= max)
        {
            return Array.Empty<double>();
        }

        var a = sides[0];
        var b = sides[1];
        var c = sides[2];

        var angles = new[]
        {
            GetAngleGammaInDegrees(a, b, c),
            GetAngleGammaInDegrees(b, c, a),
            GetAngleGammaInDegrees(c, a, b)
        };

        Array.Sort(angles);
        return angles;
    }

    private static double GetAngleGammaInDegrees(int a, int b, int c)
    {
        var cosGamma = 1d * (a * a + b * b - c * c) / (2 * a * b);
        var gammaInRadians = Math.Acos(cosGamma);
        var gammaInDegrees = gammaInRadians * 180 / Math.PI;
        return gammaInDegrees;
    }
}
