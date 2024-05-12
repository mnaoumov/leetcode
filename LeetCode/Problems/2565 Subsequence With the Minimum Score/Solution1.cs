using JetBrains.Annotations;

namespace LeetCode.Problems._2565_Subsequence_With_the_Minimum_Score;

/// <summary>
/// https://leetcode.com/submissions/detail/897214426/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumScore(string s, string t)
    {
        var m = s.Length;
        var n = t.Length;
        var leftmost = Enumerable.Repeat(m + 1, n + 1).ToArray();
        var rightmost = Enumerable.Repeat(-1, n + 1).ToArray();

        leftmost[0] = 0;

        var k = 1;

        for (var i = 1; i <= n; i++)
        {
            while (k <= m && s[k - 1] != t[i - 1])
            {
                k++;
            }

            if (k == m + 1)
            {
                break;
            }

            leftmost[i] = k;
            k++;
        }

        rightmost[n] = m;
        k = m - 1;

        for (var i = n - 1; i >= 0; i--)
        {
            while (k >= 0 && s[k] != t[i])
            {
                k--;
            }

            if (k == -1)
            {
                break;
            }

            rightmost[i] = k;
            k--;
        }

        var result = int.MaxValue;

        for (var i = 0; i <= n; i++)
        {
            var j = Array.BinarySearch(rightmost, leftmost[i]);

            if (j < 0)
            {
                j = ~j;
            }

            if (j <= n)
            {
                result = Math.Min(result, j - i);
            }
        }

        return result;
    }
}
