using JetBrains.Annotations;

namespace LeetCode.Problems._0028_Find_the_Index_of_the_First_Occurrence_in_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/829014347/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int StrStr(string haystack, string needle)
    {
        if (haystack.Length < needle.Length)
        {
            return -1;
        }

        for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            var found = !needle.Where((t, j) => haystack[i + j] != t).Any();

            if (found)
            {
                return i;
            }
        }

        return -1;
    }
}
