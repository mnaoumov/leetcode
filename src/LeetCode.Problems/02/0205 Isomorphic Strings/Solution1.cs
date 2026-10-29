namespace LeetCode.Problems._0205_Isomorphic_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/898980124/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsIsomorphic(string s, string t)
    {
        var n = s.Length;
        var sToTMap = new Dictionary<char, char>();
        var tToSMap = new Dictionary<char, char>();

        for (var i = 0; i < n; i++)
        {
            var sLetter = s[i];
            var tLetter = t[i];

            if (sToTMap.TryGetValue(sLetter, out var previousTLetter) && previousTLetter != tLetter)
            {
                return false;
            }

            if (tToSMap.TryGetValue(tLetter, out var previousSLetter) && previousSLetter != sLetter)
            {
                return false;
            }

            sToTMap[sLetter] = tLetter;
            tToSMap[tLetter] = sLetter;
        }

        return true;
    }
}
