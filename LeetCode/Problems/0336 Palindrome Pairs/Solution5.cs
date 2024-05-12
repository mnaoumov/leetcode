using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0336_Palindrome_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/963964327/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        var map = new Dictionary<string, int>();
        var ans = new List<IList<int>>();

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            map[word] = i;
        }

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];

            if (IsPalindrome(word, 0, word.Length - 1) && map.TryGetValue("", out var j2) && j2 != i)
            {
                ans.Add(new[] { i, j2 });
                ans.Add(new[] { j2, i });
            }

            var reversePrefix = new StringBuilder();

            for (var k = 0; k < word.Length; k++)
            {
                reversePrefix.Insert(0, word[k]);

                if (map.TryGetValue(reversePrefix.ToString(), out var j) && j != i && IsPalindrome(word, k + 1, word.Length - 1))
                {
                    ans.Add(new[] { i, j });
                }
            }

            var reverseSuffix = new StringBuilder();

            for (var k = word.Length - 1; k >= 1; k--)
            {
                reverseSuffix.Append(word[k]);

                if (map.TryGetValue(reverseSuffix.ToString(), out var j3) && j3 != i && IsPalindrome(word, 0, k - 1))
                {
                    ans.Add(new[] { j3, i });
                }
            }
        }

        return ans;
    }

    private static bool IsPalindrome(string word, int startIndex, int endIndex)
    {
        var i = startIndex;
        var j = endIndex;

        while (i < j)
        {
            if (word[i] != word[j])
            {
                return false;
            }
            i++;
            j--;
        }

        return true;
    }
}
