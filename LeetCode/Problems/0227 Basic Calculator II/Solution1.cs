using JetBrains.Annotations;

namespace LeetCode.Problems._0227_Basic_Calculator_II;

/// <summary>
/// https://leetcode.com/submissions/detail/941805071/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Calculate(string s)
    {
        var numbers = new Stack<long>();
        var operators = new Stack<char>();
        numbers.Push(0L);

        foreach (var symbol in s.Append(default))
        {
            if (symbol == ' ')
            {
                continue;
            }

            if (char.IsDigit(symbol))
            {
                var digit = symbol - '0';
                numbers.Push(numbers.Pop() * 10 + digit);
                continue;
            }

            while (operators.Count > 0)
            {
                var previousOperator = operators.Pop();
                var num2 = numbers.Pop();
                var num1 = numbers.Pop();

                if (previousOperator == '*')
                {
                    numbers.Push(num1 * num2);
                }
                else if (previousOperator == '/')
                {
                    numbers.Push(num1 / num2);
                }
                else
                {
                    var hasHigherPrecedence = symbol is '*' or '/';

                    if (!hasHigherPrecedence)
                    {
                        switch (previousOperator)
                        {
                            case '+':
                                numbers.Push(num1 + num2);
                                break;
                            case '-':
                                numbers.Push(num1 - num2);
                                break;
                        }
                    }
                    else
                    {
                        numbers.Push(num1);
                        numbers.Push(num2);
                        operators.Push(previousOperator);
                        break;
                    }
                }
            }

            if (symbol == default)
            {
                break;
            }

            operators.Push(symbol);
            numbers.Push(0);
        }

        return (int) numbers.Pop();
    }
}
