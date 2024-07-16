using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._1190_Reverse_Substrings_Between_Each_Pair_of_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/1322640092/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReverseParentheses(string s)
    {
        var stack = new Stack<StringBuilder>();
        stack.Push(new StringBuilder());

        foreach (var symbol in s)
        {
            switch (symbol)
            {
                case '(':
                    stack.Push(new StringBuilder());
                    break;
                case ')':
                {
                    var sb = stack.Pop();

                    for (var i = sb.Length - 1; i >= 0; i--)
                    {
                        stack.Peek().Append(sb[i]);
                    }

                    break;
                }
                default:
                    stack.Peek().Append(symbol);
                    break;
            }
        }

        return stack.Pop().ToString();
    }
}
