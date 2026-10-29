namespace LeetCode.Problems._1930_Unique_Length_3_Palindromic_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/1098376958/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPalindromicSubsequence(string s)
    {
        var n = s.Length;
        const int lettersCount = 'z' - 'a' + 1;
        var prefixLetterCounts = new int[n + 1, lettersCount];

        const int notFound = -1;
        var firstLetterIndices = Enumerable.Repeat(notFound, lettersCount).ToArray();
        var lastLetterIndices = Enumerable.Repeat(notFound, lettersCount).ToArray();

        for (var i = 0; i < n; i++)
        {
            int letterIndex;
            for (letterIndex = 0; letterIndex < lettersCount; letterIndex++)
            {
                prefixLetterCounts[i + 1, letterIndex] = prefixLetterCounts[i, letterIndex];
            }

            letterIndex = s[i] - 'a';
            prefixLetterCounts[i + 1, letterIndex]++;

            if (firstLetterIndices[letterIndex] == notFound)
            {
                firstLetterIndices[letterIndex] = i;
            }

            lastLetterIndices[letterIndex] = i;
        }

        var ans = 0;

        for (var letterIndex = 0; letterIndex < lettersCount; letterIndex++)
        {
            var lastIndex = lastLetterIndices[letterIndex];
            var firstIndex = firstLetterIndices[letterIndex];

            if (lastIndex - firstIndex < 2)
            {
                continue;
            }

            for (var letterIndex2 = 0; letterIndex2 < lettersCount; letterIndex2++)
            {
                if (prefixLetterCounts[lastIndex, letterIndex2] - prefixLetterCounts[firstIndex + 1, letterIndex2] > 0)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
