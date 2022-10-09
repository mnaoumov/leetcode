namespace LeetCode._0020_Valid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/810308208/
/// </summary>
public class Solution2 : ISolution
{
    public bool IsValid(string s)
    {
        var bracketsMap = new Dictionary<char, char>
        {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}'
        };

        var bracketsStack = new Stack<char>();

        foreach (var symbol in s)
        {
            switch (symbol)
            {
                case '(':
                case '[':
                case '{':
                    bracketsStack.Push(symbol);
                    break;

                case ')':
                case ']':
                case '}':
                    if (!bracketsStack.TryPop(out var lastOpenBracket))
                    {
                        return false;
                    }

                    if (bracketsMap[lastOpenBracket] != symbol)
                    {
                        return false;
                    }
                    break;
            }
        }

        return bracketsStack.Count == 0;
    }
}