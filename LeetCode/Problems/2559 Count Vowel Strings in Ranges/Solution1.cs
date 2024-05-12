using JetBrains.Annotations;

namespace LeetCode.Problems._2559_Count_Vowel_Strings_in_Ranges;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-331/submissions/detail/891698173/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        var countsExclusive = new int[words.Length + 1];

        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var isProperWord = vowels.Contains(word[0]) && vowels.Contains(word[^1]);
            countsExclusive[i + 1] = countsExclusive[i] + (isProperWord ? 1 : 0);
        }

        return queries.Select(query => countsExclusive[query[1] + 1] - countsExclusive[query[0]]).ToArray();
    }
}
