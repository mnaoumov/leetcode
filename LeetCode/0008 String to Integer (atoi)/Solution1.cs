// ReSharper disable All
using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0008_String_to_Integer__atoi_;

/// <summary>
/// https://leetcode.com/submissions/detail/148645507/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MyAtoi(string str)
    {
        var result = 0;
        bool hasSign = false;
        bool isPositiveSign = true;
        bool onlyWhiteSpace = true;

        foreach (var symbol in str)
        {
            if (char.IsDigit(symbol))
            {
                onlyWhiteSpace = false;
                int digit = symbol - '0';
                if (result > int.MaxValue / 10)
                    return int.MaxValue;
                if (result < int.MinValue / 10)
                    return int.MinValue;
                result = result * 10;

                if (result > int.MaxValue - digit)
                    return int.MaxValue;
                if (result < int.MinValue + digit)
                    return int.MinValue;

                if (result < 0 || !isPositiveSign)
                    result = result - digit;
                else
                    result = result + digit;
            }
            else if (symbol == '+' && !hasSign)
            {
                hasSign = true;
                onlyWhiteSpace = false;
            }
            else if (symbol == '-' && !hasSign)
            {
                hasSign = true;
                isPositiveSign = false;
                onlyWhiteSpace = false;
            }
            else if (char.IsWhiteSpace(symbol) && onlyWhiteSpace)
                continue;
            else
                return result;
        }

        return result;
    }
}