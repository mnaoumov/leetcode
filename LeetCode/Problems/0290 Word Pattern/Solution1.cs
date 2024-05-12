using JetBrains.Annotations;

namespace LeetCode.Problems._0290_Word_Pattern;

/// <summary>
/// https://leetcode.com/submissions/detail/868780285/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ');
        if (words.Length != pattern.Length)
        {
            return false;
        }

        var map = new Dictionary<char, string>();
        var mappedWords = new HashSet<string>();

        foreach (var (letter, word) in pattern.Zip(words))
        {
            if (!map.TryGetValue(letter, out var value))
            {
                if (!mappedWords.Add(word))
                {
                    return false;
                }

                map[letter] = word;
            }
            else
            {
                if (value != word)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
