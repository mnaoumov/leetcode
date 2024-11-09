namespace LeetCode.Problems._2955_Number_of_Same_End_Substrings;

/// <summary>
/// https://leetcode.com/submissions/detail/1439445975/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SameEndSubstringCount(string s, int[][] queries)
    {
        var n = s.Length;
        const int lettersCount = 26;
        var prefixCounts = new int[n + 1, lettersCount];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < lettersCount; j++)
            {
                prefixCounts[i + 1, j] = prefixCounts[i, j];
            }

            prefixCounts[i + 1, s[i] - 'a']++;
        }

        var m = queries.Length;
        var ans = new int[m];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < lettersCount; j++)
            {
                var letterCount = prefixCounts[queries[i][1] + 1, j] - prefixCounts[queries[i][0], j];
                ans[i] += letterCount * (letterCount + 1) / 2;
            }
        }

        return ans;
    }
}
