using JetBrains.Annotations;

namespace LeetCode._0605_Can_Place_Flowers;

/// <summary>
/// https://leetcode.com/submissions/detail/918526461/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

            flowerbed[i] = 1;
            n--;

            if (n == 0)
            {
                return true;
            }
        }

        return false;
    }
}
