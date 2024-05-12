using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._1323_Maximum_69_Number;

/// <summary>
/// https://leetcode.com/problems/maximum-69-number/submissions/838361180/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Maximum69Number(int num)
    {
        var sb = new StringBuilder();
        sb.Append(num);

        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] != '6')
            {
                continue;
            }

            sb[i] = '9';
            break;
        }

        return int.Parse(sb.ToString());
    }
}
