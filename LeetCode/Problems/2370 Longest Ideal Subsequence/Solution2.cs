using JetBrains.Annotations;

namespace LeetCode._2370_Longest_Ideal_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/1242043084/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestIdealString(string s, int k)
    {
        const int lettersCount = 26;
        var maxLengths = new int[lettersCount];
        var ans = 0;

        foreach (var letterIndex in s.Select(letter => letter - 'a'))
        {
            maxLengths[letterIndex] = 1 + Range(Math.Max(0, letterIndex - k), Math.Min(lettersCount - 1, letterIndex + k))
                .Max(previousLetter => maxLengths[previousLetter]);
            ans = Math.Max(ans, maxLengths[letterIndex]);
        }

        return ans;
    }

    private static IEnumerable<int> Range(int a, int b)
    {
        for (var x = a; x <= b; x++)
        {
            yield return x;
        }
    }
}
