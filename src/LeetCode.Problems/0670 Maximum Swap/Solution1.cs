using System.Text;

namespace LeetCode.Problems._0670_Maximum_Swap;

/// <summary>
/// https://leetcode.com/submissions/detail/1424882182/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumSwap(int num)
    {
        var lastIndices = new int[10];
        var str = num.ToString();
        for (var i = 0; i < str.Length; i++)
        {
            lastIndices[str[i] - '0'] = i;
        }

        var sorted = str.ToCharArray().OrderByDescending(x => x).ToArray();

        var sb = new StringBuilder(num.ToString());

        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] == sorted[i])
            {
                continue;
            }

            sb[i] = sorted[i];
            var lastIndex = lastIndices[sorted[i] - '0'];
            sb[lastIndex] = str[i];
            break;
        }

        return Convert.ToInt32(sb.ToString());
    }
}
