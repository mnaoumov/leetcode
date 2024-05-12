using JetBrains.Annotations;

namespace LeetCode.Problems._0392_Is_Subsequence;

/// <summary>
/// https://leetcode.com/problems/is-subsequence/submissions/853562534/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool IsSubsequence(string s, string t)
    {
        var tLetterIndicesMap = t.Select((letter, index) => (letter, index)).GroupBy(p => p.letter, p => p.index)
            .ToDictionary(g => g.Key, g => g.ToArray());

        const int notFound = -1;

        var tIndex = notFound;

        foreach (var sLetter in s)
        {
            if (!tLetterIndicesMap.ContainsKey(sLetter))
            {
                return false;
            }

            var previousTIndex = tIndex;
            tIndex = tLetterIndicesMap[sLetter].FirstOrDefault(index => index > previousTIndex, notFound);

            if (tIndex == notFound)
            {
                return false;
            }
        }

        return true;
    }
}
