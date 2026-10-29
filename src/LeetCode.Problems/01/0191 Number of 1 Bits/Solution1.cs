namespace LeetCode.Problems._0191_Number_of_1_Bits;

/// <summary>
/// https://leetcode.com/submissions/detail/923296123/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int HammingWeight(uint n)
    {
        var result = 0;

        while (n > 0)
        {
            result += (n & 1) == 1 ? 1 : 0;
            n >>= 1;
        }

        return result;
    }
}
