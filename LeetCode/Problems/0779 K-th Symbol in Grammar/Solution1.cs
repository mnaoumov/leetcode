using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0779_K_th_Symbol_in_Grammar;

/// <summary>
/// https://leetcode.com/submissions/detail/1083483246/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int KthGrammar(int n, int k)
    {
        var sb = new StringBuilder("0");

        for (var i = 2; i <= n; i++)
        {
            sb.Replace("0", "23").Replace("1", "32").Replace("2", "0").Replace("3", "1");
        }

        return sb[k - 1] - '0';
    }
}
