namespace LeetCode.Problems._0605_Can_Place_Flowers;

/// <summary>
/// https://leetcode.com/submissions/detail/918525459/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (n == 0)
        {
            return true;
        }

        for (var i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 1
                || i > 0 && flowerbed[i - 1] == 1
                || i < flowerbed.Length - 1 && flowerbed[i + 1] == 1)
            {
                continue;
            }

            n--;

            if (n == 0)
            {
                return true;
            }
        }

        return false;
    }
}
