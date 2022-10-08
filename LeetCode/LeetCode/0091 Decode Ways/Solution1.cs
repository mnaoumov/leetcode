// ReSharper disable All
namespace LeetCode._0091_Decode_Ways;

/// <summary>
/// https://leetcode.com/submissions/detail/812369551/
/// </summary>
public class Solution1 : ISolution
{
    public int NumDecodings(string s)
    {
        var cache = new int?[s.Length];
        return NumDecodings(0);

        int NumDecodings(int index)
        {
            if (index == s.Length)
            {
                return 1;
            }

            if (index > s.Length)
            {
                return 0;
            }

            if (cache[index] is { } result)
            {
                return result;
            }
            else
            {
                return (int)(cache[index] = CalculateNumDecodings(index));
            }
        }

        int CalculateNumDecodings(int index)
        {
            var digit = GetDigit(index);

            if (digit == 0)
            {
                return 0;
            }

            var result = NumDecodings(index + 1);

            switch (digit)
            {
                case 1:
                case 2 when index + 1 < s.Length && GetDigit(index + 1) <= 6:
                    result += NumDecodings(index + 2);
                    break;
            }

            return result;
        }

        int GetDigit(int index)
        {
            return s[index] - '0';
        }
    }
}