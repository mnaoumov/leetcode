namespace LeetCode.Problems._3614_Process_String_with_Special_Operations_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-458/problems/process-string-with-special-operations-ii/submissions/1695865478/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public char ProcessStr(string s, long k)
    {
        var n = s.Length;
        var lengths = new long[n];

        for (var i = 0; i < n; i++)
        {
            var symbol = s[i];
            var previousLength = i > 0 ? lengths[i - 1] : 0;

            lengths[i] = symbol switch
            {
                _ when char.IsLetter(symbol) => previousLength + 1,
                '*' => Math.Max(previousLength - 1, 0),
                '#' => previousLength * 2,
                '%' => previousLength,
                _ => throw new ArgumentException($"Unexpected symbol: {symbol}")
            };
        }

        var resultIndex = k;

        for (var index = n - 1; index >= 0; index--)
        {
            var length = lengths[index];
            if (length <= resultIndex)
            {
                return '.';
            }

            var symbol = s[index];

            switch (symbol)
            {
                case { } when char.IsLetter(symbol):
                    if (resultIndex == length - 1)
                    {
                        return symbol;
                    }
                    break;
                case '*':
                    break;
                case '#':
                    if (resultIndex >= length / 2)
                    {
                        resultIndex -= length / 2;
                    }
                    break;
                case '%':
                    resultIndex = length - 1 - resultIndex;
                    break;
            }
        }

        return '.';
    }
}
