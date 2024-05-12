using JetBrains.Annotations;

namespace LeetCode.Problems._2904_Shortest_and_Lexicographically_Smallest_Beautiful_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-367/submissions/detail/1075450664/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ShortestBeautifulSubstring(string s, int k)
    {
        var n = s.Length;

        var len = int.MaxValue;
        var ans = "";

        for (var i = 0; i < n; i++)
        {
            if (s[i] == '0')
            {
                continue;
            }

            var onesCount = 0;

            for (var j = i; j < n; j++)
            {
                if (s[j] == '0')
                {
                    continue;
                }

                onesCount++;

                if (onesCount < k)
                {
                    continue;
                }

                var newLen = j - i + 1;

                if (newLen < len)
                {
                    len = newLen;
                    ans = "";
                }

                if (newLen == len)
                {
                    var newAns = s[i..(j + 1)];

                    if (ans == "" || string.Compare(newAns, ans, StringComparison.Ordinal) < 0)
                    {
                        ans = newAns;
                    }
                }

                break;
            }
        }

        return ans;
    }
}
