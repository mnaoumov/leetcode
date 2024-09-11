using System.Text.RegularExpressions;

namespace LeetCode.Problems._0439_Ternary_Expression_Parser;

/// <summary>
/// https://leetcode.com/submissions/detail/1001409791/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ParseTernary(string expression)
    {
        while (true)
        {
            if (expression.Length == 1)
            {
                return expression;
            }

            var j = expression.Length - 1;
            char? atomicResult;

            while (true)
            {
                atomicResult = GetAtomicResult(expression[(j - 4)..(j + 1)]);

                if (atomicResult != null)
                {
                    break;
                }

                j--;
            }

            expression = expression[..(j - 4)] + atomicResult + expression[(j + 1)..];
        }
    }

    private static char? GetAtomicResult(string s)
    {
#pragma warning disable SYSLIB1045
        var match = Regex.Match(s, @"^([TF])\?([TF\d])\:([TF\d])$");
#pragma warning restore SYSLIB1045

        if (!match.Success)
        {
            return null;
        }

        var isTrue = match.Groups[1].Value == "T";
        var groupIndex = isTrue ? 2 : 3;
        return match.Groups[groupIndex].Value[0];
    }
}
