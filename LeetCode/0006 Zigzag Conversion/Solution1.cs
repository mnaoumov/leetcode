using System.Text;

using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0006_Zigzag_Conversion;

/// <summary>
/// https://leetcode.com/submissions/detail/148141552/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string Convert(string s, int numRows)
    {
        var period = 2 * numRows - 2;

        var sb = new StringBuilder();

        for (int i = 0; i < numRows; i++)
        {
            var j = period - i;
            var skipJ = i == 0 || i == numRows - 1;
            var nextI = i;
            var nextJ = j;
            while (nextI < s.Length)
            {
                sb.Append(s[nextI]);
                if (!skipJ && nextJ < s.Length)
                    sb.Append(s[nextJ]);
                nextI += period;
                nextJ += period;
            }
        }

        return sb.ToString();
    }
}
