using JetBrains.Annotations;

namespace LeetCode._0439_Ternary_Expression_Parser;

/// <summary>
/// https://leetcode.com/submissions/detail/1001414011/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string ParseTernary(string expression)
    {
        var stack = new Stack<char>();
        for (var j = expression.Length - 1; j >= 0; j--)
        {
            var symbol = expression[j];

            switch (symbol)
            {
                case 'T':
                case 'F':
                case { } when char.IsDigit(symbol):
                    stack.Push(symbol);
                    break;
                case '?':
                    var trueValue = stack.Pop();
                    var falseValue = stack.Pop();
                    stack.Push(expression[j - 1] == 'T' ? trueValue : falseValue);
                    j--;
                    break;
            }
        }

        return stack.Pop().ToString();
    }
}
