using System.Text;

namespace LeetCode.Problems._1249_Minimum_Remove_to_Make_Valid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/941808995/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MinRemoveToMakeValid(string s)
    {
        var sb = new StringBuilder();
        var stack = new Stack<int>();

        foreach (var symbol in s)
        {
            switch (symbol)
            {
                case '(':
                    sb.Append(symbol);
                    stack.Push(sb.Length - 1);
                    break;
                case ')':
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        sb.Append(symbol);
                    }
                    break;
                default:
                    sb.Append(symbol);
                    break;
            }
        }

        while (stack.Count > 0)
        {
            sb.Remove(stack.Pop(), 1);
        }

        return sb.ToString();
    }
}
