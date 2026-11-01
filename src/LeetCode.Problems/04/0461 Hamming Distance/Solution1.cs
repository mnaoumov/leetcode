namespace LeetCode.Problems._0461_Hamming_Distance;

/// <seealso href="https://leetcode.com/submissions/detail/921922113/"/>
/// <seealso href="https://leetcode.com/submissions/detail/921922243/"/>
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
