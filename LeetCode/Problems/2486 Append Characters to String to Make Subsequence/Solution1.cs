using JetBrains.Annotations;

namespace LeetCode._2486_Append_Characters_to_String_to_Make_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/850794200/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AppendCharacters(string s, string t)
    {
        var sIndex = 0;
        var tIndex = 0;

        while (sIndex < s.Length && tIndex < t.Length)
        {
            if (s[sIndex] == t[tIndex])
            {
                tIndex++;
            }

            sIndex++;
        }

        return t.Length - tIndex;
    }
}
