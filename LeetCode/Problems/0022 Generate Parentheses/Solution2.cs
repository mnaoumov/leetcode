using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0022_Generate_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/918875907/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var combination = new StringBuilder();
        var openCount = 0;
        Backtrack();
        return result;

        void Backtrack()
        {
            if (combination.Length == 2 * n)
            {
                result.Add(combination.ToString());
                return;
            }

            if (openCount < n)
            {
                combination.Append('(');
                openCount++;
                Backtrack();
                combination.Remove(combination.Length - 1, 1);
                openCount--;
            }

            if (openCount <= combination.Length / 2)
            {
                return;
            }

            combination.Append(')');
            Backtrack();
            combination.Remove(combination.Length - 1, 1);
        }
    }
}
