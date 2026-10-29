namespace LeetCode.Problems._3365_Rearrange_K_Substrings_to_Form_Target_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-425/submissions/detail/1461255599/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPossibleToRearrange(string s, string t, int k)
    {
        var n = s.Length;
        var m = n / k;
        var sParts = new List<string>();
        var tParts = new List<string>();

        for (var i = 0; i < k; i++)
        {
            sParts.Add(s.Substring(i * m, m));
            tParts.Add(t.Substring(i * m, m));
        }

        sParts.Sort();
        tParts.Sort();

        return sParts.SequenceEqual(tParts);
    }
}
