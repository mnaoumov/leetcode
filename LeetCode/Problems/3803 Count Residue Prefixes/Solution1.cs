namespace LeetCode.Problems._3803_Count_Residue_Prefixes;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-484/problems/count-residue-prefixes/submissions/1881248525/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ResiduePrefixes(string s)
    {
        var uniqueLetters = new HashSet<char>();
        var ans = 0;
        for (var i = 0; i < s.Length; i++)
        {
            uniqueLetters.Add(s[i]);

            if (uniqueLetters.Count == 3)
            {
                break;
            }

            if (uniqueLetters.Count == (i + 1) % 3)
            {
                ans++;
            }
        }

        return ans;
    }
}
