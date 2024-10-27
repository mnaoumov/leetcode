namespace LeetCode.Problems._1106_Parsing_A_Boolean_Expression;

/// <summary>
/// https://leetcode.com/submissions/detail/1427787547/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ParseBoolExpr(string expression)
    {
        var operands = new Stack<char>();
        var values = new Stack<bool>();
        var argumentCounts = new Stack<int>();
        argumentCounts.Push(0);

        const char trueValue = 't';
        const char falseValue = 'f';
        const char notOperand = '!';
        const char andOperand = '&';
        const char orOperand = '|';

        foreach (var symbol in expression)
        {
            switch (symbol)
            {
                case trueValue:
                    AddValue(true);
                    break;
                case falseValue:
                    AddValue(false);
                    break;
                case notOperand:
                case andOperand:
                case orOperand:
                    operands.Push(symbol);
                    argumentCounts.Push(0);
                    break;
                case ')':
                    var operand = operands.Pop();
                    var argumentCount = argumentCounts.Pop();
                    var arguments = new bool[argumentCount];
                    for (var i = 0; i < argumentCount; i++)
                    {
                        arguments[i] = values.Pop();
                    }
                    switch (operand)
                    {
                        case notOperand:
                            AddValue(!arguments[0]);
                            break;
                        case andOperand:
                            AddValue(arguments.All(value => value));
                            break;
                        case orOperand:
                            AddValue(arguments.Any(value => value));
                            break;
                    }
                    break;
            }
        }

        return values.Pop();

        void AddValue(bool value)
        {
            values.Push(value);
            argumentCounts.Push(argumentCounts.Pop() + 1);
        }
    }
}
