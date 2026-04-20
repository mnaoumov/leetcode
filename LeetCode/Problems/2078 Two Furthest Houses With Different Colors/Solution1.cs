namespace LeetCode.Problems._2078_Two_Furthest_Houses_With_Different_Colors;

/// <summary>
/// https://leetcode.com/problems/two-furthest-houses-with-different-colors/submissions/1983128370/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDistance(int[] colors)
    {
        for (var length = colors.Length - 1; length >= 1; length--)
        {
            for (var i = 0; i < colors.Length - length; i++)
            {
                if (colors[i] != colors[i + length])
                {
                    return length;
                }
            }
        }

        return 0;
    }
}
