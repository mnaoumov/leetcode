namespace LeetCode.Problems._0880_Decoded_String_at_Index;

/// <summary>
/// https://leetcode.com/submissions/detail/1060934562/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string DecodeAtIndex(string s, int k)
    {
        var symbolIndex = 0;
        var length = 0L;

        while (true)
        {
            var symbol = s[symbolIndex];

            if (char.IsLetter(symbol))
            {
                length++;
            }
            else
            {
                var count = symbol - '0';
                length *= count;
            }

            if (length >= k)
            {
                break;
            }

            symbolIndex++;
        }

        for (var i = symbolIndex; i >= 0; i--)
        {
            k = (int) (k % length);

            var symbol = s[i];

            if (k == 0 && char.IsLetter(symbol))
            {
                return symbol.ToString();
            }

            if (char.IsLetter(symbol))
            {
                length--;
            }
            else
            {
                length /= symbol - '0';
            }
        }

        throw new InvalidOperationException();
    }
}
