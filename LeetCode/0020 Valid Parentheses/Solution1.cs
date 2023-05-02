using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0020_Valid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/196727004/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsValid(string s)
    {
        var openBrackets = new Dictionary<char, BracketType>
        {
            ['('] = BracketType.Round,
            ['['] = BracketType.Square,
            ['{'] = BracketType.Curly
        };

        var closeBrackets = new Dictionary<char, BracketType>
        {
            [')'] = BracketType.Round,
            [']'] = BracketType.Square,
            ['}'] = BracketType.Curly
        };

        var brackets = new Stack<BracketType>();

        foreach (var symbol in s)
        {
            if (openBrackets.ContainsKey(symbol))
            {
                brackets.Push(openBrackets[symbol]);
            }
            else if (closeBrackets.ContainsKey(symbol))
            {
                if (brackets.Count == 0)
                {
                    return false;
                }

                var closeBracketType = closeBrackets[symbol];
                var lastBracketType = brackets.Pop();

                if (closeBracketType != lastBracketType)
                {
                    return false;
                }
            }
        }

        return brackets.Count == 0;
    }

    private enum BracketType
    {
        Round,
        Square,
        Curly

    }
}
