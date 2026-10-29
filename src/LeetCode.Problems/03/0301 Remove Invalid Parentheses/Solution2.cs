using System.Text;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0301_Remove_Invalid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/198518868/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        var wrongOpenParentheses = 0;
        var wrongClosedParentheses = 0;
        foreach (var symbol in s)
        {
            switch (symbol)
            {
                case '(':
                    wrongOpenParentheses++;
                    break;
                case ')':
                    if (wrongOpenParentheses > 0)
                    {
                        wrongOpenParentheses--;
                    }
                    else
                    {
                        wrongClosedParentheses++;
                    }
                    break;
            }
        }

        var results = new HashSet<string>();
        RemoveInvalidParentheses(s, 0, 0, wrongOpenParentheses, wrongClosedParentheses, new StringBuilder(), results);
        return results.ToArray();
    }

    private void RemoveInvalidParentheses(string s, int index,
        int balance, int wrongOpenParentheses, int wrongClosedParentheses,
        StringBuilder builder, HashSet<string> results)
    {
        if (wrongOpenParentheses < 0 || wrongClosedParentheses < 0 || balance < 0)
        {
            return;
        }

        if (index == s.Length)
        {
            if (wrongOpenParentheses == 0 && wrongClosedParentheses == 0 && balance == 0)
            {
                results.Add(builder.ToString());
            }

            return;
        }

        var symbol = s[index];
        var length = builder.Length;

        switch (symbol)
        {
            case '(':
                RemoveInvalidParentheses(s, index + 1, balance, wrongOpenParentheses - 1, wrongClosedParentheses, builder, results);

                builder.Append(symbol);
                RemoveInvalidParentheses(s, index + 1, balance + 1, wrongOpenParentheses, wrongClosedParentheses, builder, results);
                builder.Remove(length, 1);
                break;
            case ')':
                RemoveInvalidParentheses(s, index + 1, balance, wrongOpenParentheses, wrongClosedParentheses - 1, builder, results);

                builder.Append(symbol);
                RemoveInvalidParentheses(s, index + 1, balance - 1, wrongOpenParentheses, wrongClosedParentheses, builder, results);
                builder.Remove(length, 1);
                break;
            default:
                builder.Append(symbol);
                RemoveInvalidParentheses(s, index + 1, balance, wrongOpenParentheses, wrongClosedParentheses, builder, results);
                builder.Remove(length, 1);
                break;
        }
    }
}
