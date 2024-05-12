using JetBrains.Annotations;

namespace LeetCode._0150_Evaluate_Reverse_Polish_Notation;

/// <summary>
/// https://leetcode.com/submissions/detail/860899888/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int EvalRPN(string[] tokens)
    {
        var numbersStack = new Stack<int>();
        var operatorsMap = new Dictionary<string, Func<int, int, int>>
        {
            ["+"] = (a, b) => a + b,
            ["-"] = (a, b) => a - b,
            ["*"] = (a, b) => a * b,
            ["/"] = (a, b) => a / b
        };

        foreach (var token in tokens)
        {
            if (operatorsMap.TryGetValue(token, out var operatorFunc))
            {
                var b = numbersStack.Pop();
                var a = numbersStack.Pop();
                var result = operatorFunc(a, b);
                numbersStack.Push(result);
            }
            else
            {

                var num = int.Parse(token);
                numbersStack.Push(num);
            }
        }

        return numbersStack.Pop();
    }
}
