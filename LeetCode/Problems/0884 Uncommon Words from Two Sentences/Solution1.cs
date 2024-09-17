namespace LeetCode.Problems._0884_Uncommon_Words_from_Two_Sentences;

/// <summary>
/// https://leetcode.com/submissions/detail/1392706473/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var set1 = GetUniqueWords(s1).ToHashSet();
        set1.SymmetricExceptWith(GetUniqueWords(s2));
        return set1.ToArray();
    }

    private static string[] GetUniqueWords(string s) => s
        .Split(' ')
        .GroupBy(word => word)
        .Where(g => g.Count() == 1)
        .Select(g => g.Key)
        .ToArray();
}
