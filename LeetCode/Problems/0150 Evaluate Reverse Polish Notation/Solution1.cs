using JetBrains.Annotations;

namespace LeetCode.Problems._0150_Evaluate_Reverse_Polish_Notation;

/// <summary>
/// https://leetcode.com/problems/evaluate-reverse-polish-notation/submissions/848088325/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EvalRPN(string[] tokens)
    {
        var numbers = new Stack<int>();

        foreach (var token in tokens)
        {
            switch (token)
            {
                case "+":
                    ProcessOperator((a, b) => a + b);
                    break;
                case "-":
                    ProcessOperator((a, b) => a - b);
                    break;
                case "*":
                    ProcessOperator((a, b) => a * b);
                    break;
                case "/":
                    ProcessOperator((a, b) => a / b);
                    break;
                default:
                    var number = int.Parse(token);
                    numbers.Push(number);
                    break;
            }
        }

        return numbers.Pop();

        void ProcessOperator(Func<int, int, int> func)
        {
            var num2 = numbers.Pop();
            var num1 = numbers.Pop();
            numbers.Push(func(num1, num2));
        }
    }
}
