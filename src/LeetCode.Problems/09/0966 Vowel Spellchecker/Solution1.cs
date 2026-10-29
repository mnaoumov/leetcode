using System.Text.RegularExpressions;

namespace LeetCode.Problems._0966_Vowel_Spellchecker;

/// <summary>
/// https://leetcode.com/problems/vowel-spellchecker/submissions/1770052490/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        var set = wordlist.ToHashSet();
        var capitalizationDict = new Dictionary<string, string>();
        var vowelErrorDict = new Dictionary<string, string>();

        foreach (var word in wordlist)
        {
            capitalizationDict.TryAdd(word.ToLower(), word);
            vowelErrorDict.TryAdd(GetVowelErrorPattern(word), word);
        }

        return queries.Select(Answer).ToArray();

        string Answer(string query)
        {
            if (set.Contains(query))
            {
                return query;
            }

            if (capitalizationDict.TryGetValue(query.ToLower(), out var capitalizationMatch))
            {
                return capitalizationMatch;
            }

            return vowelErrorDict.GetValueOrDefault(GetVowelErrorPattern(query), "");
        }
    }

    private static string GetVowelErrorPattern(string str) => Regex.Replace(str.ToLower(), "[aeiou]", "_");
}
