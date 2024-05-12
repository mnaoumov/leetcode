using JetBrains.Annotations;

namespace LeetCode.Problems._2586_Count_the_Number_of_Vowel_Strings_in_Range;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-336/submissions/detail/913509835/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int VowelStrings(string[] words, int left, int right)
    {
        var result = 0;
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        for (var i = left; i <= right; i++)
        {
            var word = words[i];

            if (vowels.Contains(word[0]) && vowels.Contains(word[^1]))
            {
                result++;
            }
        }

        return result;
    }
}
