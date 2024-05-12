using JetBrains.Annotations;

namespace LeetCode.Problems._3146_Permutation_Difference_between_Two_Strings;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-397/submissions/detail/1255677241/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindPermutationDifference(string s, string t)
    {
        var tIndices = new Dictionary<char, int>();

        var n = s.Length;

        for (var i = 0; i < n; i++)
        {
            tIndices[t[i]] = i;
        }

        return Enumerable.Range(0, n).Select(index => Math.Abs(index - tIndices[s[index]])).Sum();
    }
}
