using System.Text;

namespace LeetCode.Problems._3271_Hash_Divided_String;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-138/submissions/detail/1374263106/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string StringHash(string s, int k)
    {
        var n = s.Length;
        var m = n / k;
        var sb = new StringBuilder
        {
            Length = m
        };

        for (var i = 0; i < m; i++)
        {
            var hash = 0;
            
            for (var j = i * k; j < (i + 1) * k; j++)
            {
                var hashValue = s[j] - 'a';
                hash = (hash + hashValue) % 26;
            }

            sb[i] = (char) ('a' + hash);
        }
        return sb.ToString();
    }
}
