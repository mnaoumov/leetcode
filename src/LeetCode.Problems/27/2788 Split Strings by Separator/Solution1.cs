namespace LeetCode.Problems._2788_Split_Strings_by_Separator;

/// <seealso href="https://leetcode.com/contest/weekly-contest-355/submissions/detail/1001420178/">Submission</seealso>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator) => words.SelectMany(word => word.Split(separator)).ToArray();
}
