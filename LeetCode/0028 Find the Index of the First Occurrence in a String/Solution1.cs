using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0028_Find_the_Index_of_the_First_Occurrence_in_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/812272924/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int StrStr(string haystack, string needle)
    {
        if (haystack.Length < needle.Length)
        {
            return -1;
        }

        for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            var found = true;
            for (int j = 0; j < needle.Length; j++)
            {
                if (haystack[i + j] != needle[j])
                {
                    found = false;
                    break;
                }
            }

            if (found)
            {
                return i;
            }
        }

        return -1;
    }
}
