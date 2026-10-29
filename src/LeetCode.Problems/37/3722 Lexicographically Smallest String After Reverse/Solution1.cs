using System.Text;

namespace LeetCode.Problems._3722_Lexicographically_Smallest_String_After_Reverse;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-168/problems/lexicographically-smallest-string-after-reverse/submissions/1811285852/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LexSmallest(string s)
    {
        var n = s.Length;
        var ans = new string('z', n);
        for (var k = 1; k <= n; k++)
        {
            var sb = new StringBuilder();
            bool? isCandidate = null;

            for (var j = 0; j < n; j++)
            {
                var letter = j < k ? s[k - 1 - j] : s[j];

                if (isCandidate == null && letter > ans[j])
                {
                    isCandidate = false;
                    break;
                }

                if (letter < ans[j])
                {
                    isCandidate = true;
                }

                sb.Append(letter);
            }

            if (isCandidate == true)
            {
                ans = sb.ToString();
            }

            sb = new StringBuilder();
            isCandidate = null;

            for (var j = 0; j < n; j++)
            {
                var letter = j < n - k ? s[j] : s[2 * n - k - 1 - j];

                if (isCandidate == null && letter > ans[j])
                {
                    isCandidate = false;
                    break;
                }

                if (letter < ans[j])
                {
                    isCandidate = true;
                }

                sb.Append(letter);
            }

            if (isCandidate == true)
            {
                ans = sb.ToString();
            }
        }

        return ans;
    }
}
