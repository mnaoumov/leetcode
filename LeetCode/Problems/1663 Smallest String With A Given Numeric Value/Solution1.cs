using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._1663_Smallest_String_With_A_Given_Numeric_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/914093118/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GetSmallestString(int n, int k)
    {
        var sb = new StringBuilder();
        var valueLeft = k - n;
        sb.Append('a', n);

        for (var i = n - 1; i >= 0; i--)
        {
            if (valueLeft == 0)
            {
                break;
            }

            valueLeft++;

            var newLetterIndex = Math.Min(valueLeft, 26);
            sb[i] = (char) (newLetterIndex - 1 + 'a');
            valueLeft -= newLetterIndex;
        }

        return sb.ToString();
    }
}
