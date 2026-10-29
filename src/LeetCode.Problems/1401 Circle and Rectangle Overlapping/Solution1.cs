namespace LeetCode.Problems._1401_Circle_and_Rectangle_Overlapping;

/// <summary>
/// https://leetcode.com/problems/circle-and-rectangle-overlapping/submissions/2146215310/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
    {
        var d2 = 0;

        if (x2 < xCenter)
        {
            d2 += Sqr(xCenter - x2);
        }
        else if (x1 > xCenter)
        {
            d2 += Sqr(x1 - xCenter);
        }

        if (y2 < yCenter)
        {
            d2 += Sqr(yCenter - y2);
        }
        else if (y1 > yCenter)
        {
            d2 += Sqr(y1 - yCenter);
        }

        return d2 <= Sqr(radius);
    }

    private static int Sqr(int n) => n * n;
}
