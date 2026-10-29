namespace LeetCode.Problems._0856_Score_of_Parentheses;

/// <summary>
/// https://leetcode.com/problems/score-of-parentheses/submissions/2163706175/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ScoreOfParentheses(string s)
    {
        var n = s.Length;
        var balances = new int[n];
        const char openBracket = '(';

        for (var i = 0; i < n; i++)
        {
            var isOpenBracket = s[i] == openBracket;
            balances[i] = (i > 0 ? balances[i - 1] : 0) + (isOpenBracket ? 1 : -1);
        }

        return Score(balances);
    }

    private static int Score(int[] balances)
    {
        if (balances.Length == 2)
        {
            if (balances[0] == 1 && balances[1] == 0)
            {
                return 1;
            }

            throw new InvalidOperationException($"Wrong balances: {string.Join(",", balances)}");
        }

        var index = balances.IndexOf(0);

        if (index == balances.Length - 1)
        {
            return 2 * Score(balances.Select(x => x - 1).Skip(1).Take(balances.Length - 2).ToArray());
        }

        return Score(balances.Take(index + 1).ToArray()) + Score(balances.Skip(index + 1).ToArray());
    }
}
