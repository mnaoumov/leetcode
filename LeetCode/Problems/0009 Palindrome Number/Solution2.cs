using JetBrains.Annotations;

namespace LeetCode._0009_Palindrome_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/828913984/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }

        return Reverse(x) == x;
    }

    private static int Reverse(int x)
    {
        var result = 0;

        while (x != 0)
        {
            var digitWithSign = x % 10;

            if (result is > int.MaxValue / 10 or < int.MinValue / 10)
            {
                return 0;
            }

            result *= 10;

            switch (x)
            {
                case > 0 when result > int.MaxValue - digitWithSign:
                case < 0 when result < int.MinValue - digitWithSign:
                    return 0;
                default:
                    result += digitWithSign;
                    x /= 10;
                    break;
            }
        }

        return result;
    }
}
