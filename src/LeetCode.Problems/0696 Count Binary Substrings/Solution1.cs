namespace LeetCode.Problems._0696_Count_Binary_Substrings;

/// <summary>
/// https://leetcode.com/problems/count-binary-substrings/submissions/1923868554/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountBinarySubstrings(string s)
    {
        var n = s.Length;
        var onePrefixCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            onePrefixCounts[i + 1] = onePrefixCounts[i] + (s[i] == '1' ? 1 : 0);
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 2; j <= n; j += 2)
            {
                var length = j - i;
                var halfOneCount = onePrefixCounts[i + length / 2] - onePrefixCounts[i];
                var count = onePrefixCounts[j] - onePrefixCounts[i];

                if (count == length / 2 && (halfOneCount == 0 || halfOneCount == length / 2))
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
