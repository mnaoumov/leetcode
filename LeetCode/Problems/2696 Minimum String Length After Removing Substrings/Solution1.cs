using System.Text;

namespace LeetCode.Problems._2696_Minimum_String_Length_After_Removing_Substrings;

/// <summary>
/// https://leetcode.com/submissions/detail/1415263534/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinLength(string s)
    {
        var sb = new StringBuilder(s);
        var isChanged = false;

        while (true)
        {
            for (var i = 0; i < sb.Length - 1; i++)
            {
                if (!StartsWith(sb, i, "AB") && !StartsWith(sb, i, "CD"))
                {
                    continue;
                }

                sb.Remove(i, 2);
                isChanged = true;
                break;
            }

            if (isChanged)
            {
                isChanged = false;
                continue;
            }

            break;
        }

        return sb.Length;
    }

    private static bool StartsWith(StringBuilder sb, int index, string prefix)
    {
        if (index < 0 || index + prefix.Length - 1 >= sb.Length)
        {
            return false;
        }

        return Enumerable.Range(0, prefix.Length).All(j => sb[index + j] == prefix[j]);
    }
}