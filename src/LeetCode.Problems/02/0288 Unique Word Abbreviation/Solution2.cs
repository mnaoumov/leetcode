using System.Globalization;

namespace LeetCode.Problems._0288_Unique_Word_Abbreviation;

/// <summary>
/// https://leetcode.com/problems/unique-word-abbreviation/submissions/2057415819/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IValidWordAbbr Create(string[] dictionary) => new ValidWordAbbr(dictionary);

    private sealed class ValidWordAbbr : IValidWordAbbr
    {
        private readonly Dictionary<string, (string matchingWord, bool isSingleMatchingWord)> _map =
            new Dictionary<string, (string matchingWord, bool isSingleMatchingWord)>();

        public ValidWordAbbr(string[] dictionary)
        {
            foreach (var word in dictionary)
            {
                var abbr = Abbreviate(word);

                if (_map.TryGetValue(abbr, out var x))
                {
                    if (x.matchingWord == word)
                    {
                        continue;
                    }

                    _map[abbr] = (x.matchingWord, false);
                }
                else
                {
                    _map[abbr] = (word, true);
                }
            }
        }

        private static string Abbreviate(string word)
        {
            if (word.Length < 3)
            {
                return word;
            }

            return word[0] + Convert.ToString(word.Length - 2, CultureInfo.InvariantCulture) + word[^1];
        }

        public bool IsUnique(string word)
        {
            var abbr = Abbreviate(word);
            return !_map.TryGetValue(abbr, out var x) || x.matchingWord == word && x.isSingleMatchingWord;
        }
    }
}
