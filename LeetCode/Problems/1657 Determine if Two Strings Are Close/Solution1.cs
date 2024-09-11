using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._1657_Determine_if_Two_Strings_Are_Close;

/// <summary>
/// https://leetcode.com/submissions/detail/853155147/
/// https://leetcode.com/submissions/detail/853160745/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CloseStrings(string word1, string word2)
    {
        var countsMap1 = CountLetters(word1);
        var countsMap2 = CountLetters(word2);

        return AreEquivalent(countsMap1.Keys, countsMap2.Keys) && AreEquivalent(countsMap1.Values, countsMap2.Values);

        Dictionary<char, int> CountLetters(string word) => word.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        bool AreEquivalent<T>(IEnumerable<T> items1, IEnumerable<T> items2) => items1.Count() == items2.Count() && !items1.Except(items2).Any() && !items2.Except(items1).Any();
    }
}
