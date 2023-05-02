using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0032_Longest_Valid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/812842176/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    private const char OpeningBracket = '(';

    public int LongestValidParentheses(string s)
    {
        var balances = new int[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            var previousBalance = i == 0 ? 0 : balances[i - 1];
            balances[i] = previousBalance + (s[i] == OpeningBracket ? 1 : -1);
        }

        var result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var previousBalance = i == 0 ? 0 : balances[i - 1];
            for (int j = i; j < s.Length; j++)
            {
                if (balances[j] < previousBalance)
                {
                    break;
                }

                if (balances[j] == previousBalance)
                {
                    result = Math.Max(result, j - i + 1);
                }
            }
        }

        return result;
    }
}
