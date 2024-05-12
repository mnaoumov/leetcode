using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._3114_Latest_Time_You_Can_Obtain_After_Replacing_Characters;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-393/submissions/detail/1231739892/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FindLatestTime(string s)
    {
        var sb = new StringBuilder(s);
        const char questionMark = '?';
        const int unknown = -1;

        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] != questionMark)
            {
                continue;
            }

            sb[i] = (char) ('0' + GetMaxDigit(i));
        }

        return sb.ToString();

        int GetDigit(int index) => int.TryParse(sb[index].ToString(), out var ans) ? ans : unknown;

        int GetMaxDigit(int index)
        {
            switch (index)
            {
                case 0:
                    var digit1 = GetDigit(1);
                    return digit1 >= 2 ? 0 : 1;
                case 1:
                    var digit0 = GetDigit(0);
                    return digit0 == 0 ? 9 : 1;
                case 3:
                    return 5;
                case 4:
                    return 9;
                default:
                    throw new ArgumentException(null, nameof(index));
            }
        }

    }
}
