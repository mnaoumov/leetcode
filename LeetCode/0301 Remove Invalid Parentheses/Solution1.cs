using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0301_Remove_Invalid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/198437890/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        return RemoveInvalidParentheses(s, 0).ToList();
    }

    private IList<string> RemoveInvalidParentheses(string s, int start)
    {
        var balance = 0;
        var balances = new int[s.Length];
        for (int i = start; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                balance++;
            }
            else if (s[i] == ')')
            {
                balance--;
            }

            if (balance < 0)
            {
                var results = new List<string>();

                var suffixResults = RemoveInvalidParentheses(s, i + 1);
                var prefixes = new HashSet<string>();
                var substring = s.Substring(start, i - start + 1);

                for (int j = start; j <= i; j++)
                {
                    if (s[j] == ')')
                    {
                        var prefix = substring.Remove(j - start, 1);
                        prefixes.Add(prefix);
                    }
                }

                foreach (var prefix in prefixes)
                {
                    foreach (var suffixResult in suffixResults)
                    {
                        results.Add(prefix + suffixResult);
                    }
                }

                return results;
            }

            balances[i] = balance;
        }

        if (balance == 0)
        {
            return new[] { s.Substring(start, s.Length - start) };
        }

        return RemoveOpenBrackets(s, start, s.Length - 1, balances, balance);
    }

    private IList<string> RemoveOpenBrackets(string s, int start, int end, int[] balances, int balance)
    {
        if (balance == 0)
        {
            return new[] { s.Substring(start, end - start + 1) };
        }

        for (int i = end; i >= start; i--)
        {
            if (s[i] == '(')
            {
                var results = new HashSet<string>();

                var prefixResults = RemoveOpenBrackets(s, start, i - 1, balances, balance - 1);
                var suffix = i < end ? s.Substring(i + 1, end - i) : "";

                foreach (var prefixResult in prefixResults)
                {
                    results.Add(prefixResult + suffix);
                }

                prefixResults = RemoveOpenBrackets(s, start, i - 1, balances, balance);
                suffix = s.Substring(i, end - i + 1);

                foreach (var prefixResult in prefixResults)
                {
                    results.Add(prefixResult + suffix);
                }

                return results.ToArray();
            }

            if (s[i] == ')' && balances[i] < balance)
            {
                return new List<string>();
            }
        }

        return new List<string>();
    }
}
