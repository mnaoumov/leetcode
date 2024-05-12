using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._1427_Perform_String_Shifts;

/// <summary>
/// https://leetcode.com/submissions/detail/945208173/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string StringShift(string s, int[][] shift)
    {
        var sb = new StringBuilder(s);
        const int leftShift = 0;

        foreach (var arr in shift)
        {
            var direction = arr[0];
            var amount = arr[1];

            for (var i = 0; i < amount; i++)
            {
                if (direction == leftShift)
                {
                    sb.Append(sb[0]);
                    sb.Remove(0, 1);
                }
                else
                {
                    sb.Insert(0, sb[^1]);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }

        return sb.ToString();
    }
}
