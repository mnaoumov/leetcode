using System.Text;
using JetBrains.Annotations;

namespace LeetCode._1047_Remove_All_Adjacent_Duplicates_In_String;

/// <summary>
/// https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/submissions/840423443/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string RemoveDuplicates(string s)
    {
        var sb = new StringBuilder(s);

        for (var i = 0; i < sb.Length - 1; i++)
        {
            if (sb[i] != sb[i + 1])
            {
                continue;
            }

            sb.Remove(i, 2);
            i = Math.Max(0, i - 1) - 1;
        }

        return sb.ToString();
    }
}
