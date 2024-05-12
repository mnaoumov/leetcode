using JetBrains.Annotations;

namespace LeetCode.Problems._0032_Longest_Valid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/829015953/
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    private const char OpeningBracket = '(';

    public int LongestValidParentheses(string s)
    {
        var balances = new int[s.Length];

        for (var i = 0; i < s.Length; i++)
        {
            var previousBalance = i == 0 ? 0 : balances[i - 1];
            balances[i] = previousBalance + (s[i] == OpeningBracket ? 1 : -1);
        }

        var result = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var previousBalance = i == 0 ? 0 : balances[i - 1];
            for (var j = i; j < s.Length; j++)
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
