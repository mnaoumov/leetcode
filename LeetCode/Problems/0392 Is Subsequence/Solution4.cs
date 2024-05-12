using JetBrains.Annotations;

namespace LeetCode._0392_Is_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/853962286/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool IsSubsequence(string s, string t)
    {
        var tLetterIndicesMap = t.Select((letter, index) => (letter, index)).GroupBy(p => p.letter, p => p.index)
            .ToDictionary(g => g.Key, g => g.ToArray());

        const int notFound = -1;

        var tIndex = notFound;

        foreach (var sLetter in s)
        {
            if (!tLetterIndicesMap.TryGetValue(sLetter, out var letterIndices))
            {
                return false;
            }

            var nextIndexOfIndices = Array.BinarySearch(letterIndices, tIndex + 1);

            if (nextIndexOfIndices < 0)
            {
                nextIndexOfIndices = ~nextIndexOfIndices;
            }

            if (nextIndexOfIndices >= letterIndices.Length)
            {
                return false;
            }

            tIndex = letterIndices[nextIndexOfIndices];
        }

        return true;
    }
}
