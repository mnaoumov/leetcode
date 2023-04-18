using JetBrains.Annotations;

namespace LeetCode._0131_Palindrome_Partitioning;

/// <summary>
/// https://leetcode.com/problems/palindrome-partitioning/submissions/836931866/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<string>> Partition(string s)
    {
        var isPalindromeDict = new Dictionary<(int startIndex, int endIndex), bool>();

        return Enumerate(0).Select(e => e.ToArray()).ToArray<IList<string>>();

        IEnumerable<IEnumerable<string>> Enumerate(int startIndex)
        {
            if (startIndex == s.Length)
            {
                yield return Array.Empty<string>();
            }

            for (var endIndex = startIndex; endIndex < s.Length; endIndex++)
            {
                if (!IsPalindrome(startIndex, endIndex))
                {
                    continue;
                }

                string? substring = null;

                foreach (var tailPartition in Enumerate(endIndex + 1))
                {
                    substring ??= s.Substring(startIndex, endIndex - startIndex + 1);
                    yield return tailPartition.Prepend(substring);
                }
            }
        }

        bool IsPalindrome(int startIndex, int endIndex)
        {
            var key = (startIndex, endIndex);

            if (startIndex >= endIndex)
            {
                return true;
            }

            if (isPalindromeDict.TryGetValue(key, out var palindrome))
            {
                return palindrome;
            }

            return isPalindromeDict[key] = s[startIndex] == s[endIndex] && IsPalindrome(startIndex + 1, endIndex - 1);
        }

    }
}
