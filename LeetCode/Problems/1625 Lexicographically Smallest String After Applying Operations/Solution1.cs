using System.Text;

namespace LeetCode.Problems._1625_Lexicographically_Smallest_String_After_Applying_Operations;

/// <summary>
/// https://leetcode.com/problems/lexicographically-smallest-string-after-applying-operations/submissions/1805416781/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FindLexSmallestString(string s, int a, int b)
    {
        var ans = s;
        var n = s.Length;

        var seen = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(s);

        while (queue.Count > 0)
        {
            var str = queue.Dequeue();

            if (!seen.Add(str))
            {
                continue;
            }

            if (string.CompareOrdinal(str, ans) < 0)
            {
                ans = str;
            }

            var sb = new StringBuilder(str);

            for (var i = 1; i < n; i += 2)
            {
                var digit = sb[i] - '0';
                var nextDigit = (digit + a) % 10;
                sb[i] = (char) (nextDigit + '0');
            }

            queue.Enqueue(sb.ToString());
            queue.Enqueue(str[^b..] + str[..^b]);
        }

        return ans;
    }
}
