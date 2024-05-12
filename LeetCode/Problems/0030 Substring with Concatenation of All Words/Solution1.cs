using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0030_Substring_with_Concatenation_of_All_Words;

/// <summary>
/// https://leetcode.com/submissions/detail/812390566/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var wordLength = words[0].Length;
        var substringLength = words.Length * wordLength;

        if (s.Length < substringLength)
        {
            return Array.Empty<int>();
        }

        var wordCountMap = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
        var wordsSet = new HashSet<string>(words);
        var lastPossibleWordIndex = s.Length - wordLength;
        var lastPossibleSubstringIndex = s.Length - substringLength;
        var possibleSubstringIndexSet = new HashSet<int>(Enumerable.Range(0, lastPossibleSubstringIndex + 1));

        for (var i = 0; i <= lastPossibleWordIndex; i++)
        {
            var word = s.Substring(i, wordLength);
            if (!wordsSet.Contains(word))
            {
                var impossibleIndex = i;
                for (var j = 0; j < words.Length; j++)
                {
                    if (impossibleIndex <= lastPossibleSubstringIndex && !possibleSubstringIndexSet.Remove(impossibleIndex))
                    {
                        break;
                    }

                    impossibleIndex -= wordLength;

                    if (impossibleIndex < 0)
                    {
                        break;
                    }
                }
            }
        }

        var result = new List<int>();

        foreach (var substringIndex in possibleSubstringIndexSet)
        {
            var wordIndex = substringIndex;
            var wordCountMapCopy = new Dictionary<string, int>(wordCountMap);
            var found = true;
            for (int j = 0; j < words.Length; j++)
            {
                var word = s.Substring(wordIndex, wordLength);
                if (wordCountMapCopy[word] == 0)
                {
                    found = false;
                    break;
                }
                else
                {
                    wordCountMapCopy[word]--;
                }
                wordIndex += wordLength;
            }

            if (found)
            {
                result.Add(substringIndex);
            }
        }

        return result;
    }
}
