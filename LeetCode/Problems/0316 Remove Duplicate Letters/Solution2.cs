using JetBrains.Annotations;

namespace LeetCode.Problems._0316_Remove_Duplicate_Letters;

/// <summary>
/// https://leetcode.com/submissions/detail/1060176634/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string RemoveDuplicateLetters(string s)
    {
        var n = s.Length;

        if (n == 0)
        {
            return "";
        }

        var lettersCount = s.ToHashSet().Count;

        var lettersSeen = new HashSet<char>();

        var minLetterIndex = n;

        for (var i = n - 1; i >= 0; i--)
        {
            var letter = s[i];
            lettersSeen.Add(letter);

            if (lettersSeen.Count == lettersCount && (minLetterIndex == n || letter <= s[minLetterIndex]))
            {
                minLetterIndex = i;
            }
        }

        var minLetter = s[minLetterIndex].ToString();
        return minLetter + RemoveDuplicateLetters(s[(minLetterIndex + 1)..].Replace(minLetter, ""));
    }
}
