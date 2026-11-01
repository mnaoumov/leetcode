namespace LeetCode.Problems._0461_Hamming_Distance;

/// <seealso href="https://leetcode.com/submissions/detail/922088233/"/>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int HammingDistance(int x, int y)
    {
        var xor = x ^ y;
        var result = 0;

        while (xor > 0)
        {
            result += xor & 1;
            xor >>= 1;
        }
        return result;
    }
}
