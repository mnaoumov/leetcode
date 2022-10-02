namespace LeetCode._091_Decode_Ways;

/// <summary>
/// https://leetcode.com/submissions/detail/812369551/
/// </summary>
public class Solution : ISolution
{
    public int NumDecodings(string s)
    {
        var cache = new int?[s.Length];
        return NumDecodingsImpl(0);

        int NumDecodingsImpl(int index)
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
                return (int) (cache[index] = CalculateNumDecodings(index));
            }
        }

        int CalculateNumDecodings(int index)
        {
            var digit = GetDigit(index);

            if (digit == 0)
            {
                return 0;
            }

            var result = NumDecodingsImpl(index + 1);

            switch (digit)
            {
                case 1:
                case 2 when index + 1 < s.Length && GetDigit(index + 1) <= 6:
                    result += NumDecodingsImpl(index + 2);
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