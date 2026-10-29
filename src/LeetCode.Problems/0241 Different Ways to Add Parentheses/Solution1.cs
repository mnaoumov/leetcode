namespace LeetCode.Problems._0241_Different_Ways_to_Add_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/950257043/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> DiffWaysToCompute(string expression)
    {
        var numbers = new List<int> { 0 };
        var operators = new List<char>();
        // ReSharper disable once RedundantAssignment
        var funcs = new Dictionary<char, Func<int, int, int>>
        {
            ['+'] = (a, b) => a + b,
            ['-'] = (a, b) => a - b,
            ['*'] = (a, b) => a * b,
            ['/'] = (a, b) => a / b
        };

        foreach (var symbol in expression)
        {
            if (char.IsDigit(symbol))
            {
                numbers[^1] = numbers[^1] * 10 + (symbol - '0');
            }
            else
            {
                operators.Add(symbol);
                numbers.Add(0);
            }
        }

        return Compute(0, numbers.Count);

        IList<int> Compute(int index, int count)
        {
            if (count == 1)
            {
                return new[] { numbers[index] };
            }

            var list = new List<int>();

            for (var count2 = 1; count2 < count; count2++)
            {
                var nums1 = Compute(index, count2);
                var nums2 = Compute(index + count2, count - count2);
                var @operator = operators[index + count2 - 1];
                var func = funcs[@operator];
                list.AddRange(nums1.SelectMany(_ => nums2, (num1, num2) => func(num1, num2)));
            }

            return list;
        }
    }
}
