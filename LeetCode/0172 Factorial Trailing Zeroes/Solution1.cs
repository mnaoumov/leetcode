using JetBrains.Annotations;

namespace LeetCode._0172_Factorial_Trailing_Zeroes;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TrailingZeroes(int n)
    {
        var result = 0;

        while (n > 0)
        {
            n /= 5;
            result += n;
        }

        return result;
    }
}
