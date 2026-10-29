namespace LeetCode.Problems._0800_Similar_RGB_Color;

/// <summary>
/// https://leetcode.com/problems/similar-rgb-color/submissions/2123459035/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const int HexBase = 16;

    public string SimilarRGB(string color)
    {
        var ab = Convert.ToInt32(color[1..3], HexBase);
        var cd = Convert.ToInt32(color[3..5], HexBase);
        var ef = Convert.ToInt32(color[5..7], HexBase);

        var bestSimilarity = int.MinValue;
        var ans = "";

        const int doubleDigitStep = 0x11;

        for (var xx = 0x00; xx < 0x100; xx += doubleDigitStep)
        {
            for (var yy = 0x00; yy < 0x100; yy += doubleDigitStep)
            {
                for (var zz = 0x00; zz < 0x100; zz += doubleDigitStep)
                {
                    var similarity = -Square(ab - xx) - Square(cd - yy) - Square(ef - zz);

                    if (similarity <= bestSimilarity)
                    {
                        continue;
                    }

                    bestSimilarity = similarity;
                    ans = $"#{xx:x2}{yy:x2}{zz:x2}";
                }
            }
        }

        return ans;
    }

    private static int Square(int x) => x * x;
}
