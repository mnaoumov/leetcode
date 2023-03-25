using JetBrains.Annotations;

namespace LeetCode._0461_Hamming_Distance;

/// <summary>
/// https://leetcode.com/submissions/detail/921922113/
/// https://leetcode.com/submissions/detail/921922243/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int HammingDistance(int x, int y)
    {
        var result = 0;

        while (x > 0 || y > 0)
        {
            result += (x ^ y) & 1;
            x >>= 1;
            y >>= 1;
        }
        return result;
    }
}
