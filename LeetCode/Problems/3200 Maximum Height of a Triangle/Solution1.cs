using JetBrains.Annotations;

namespace LeetCode.Problems._3200_Maximum_Height_of_a_Triangle;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-404/submissions/detail/1304375228/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxHeightOfTriangle(int red, int blue) => Math.Max(MaxHeightOfTriangle2(red, blue), MaxHeightOfTriangle2(blue, red));

    private static int MaxHeightOfTriangle2(int color1, int color2)
    {
        var ans = 0;

        while (true)
        {
            ref var currentColorRef = ref ans % 2 == 0 ? ref color1 : ref color2;

            if (currentColorRef < ans + 1)
            {
                break;
            }

            currentColorRef -= ans + 1;

            ans++;
        }

        return ans;
    }
}
