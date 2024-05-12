using JetBrains.Annotations;

namespace LeetCode.Problems._2788_Split_Strings_by_Separator;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-355/submissions/detail/1001420178/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator) => words.SelectMany(word => word.Split(separator)).ToArray();
}
