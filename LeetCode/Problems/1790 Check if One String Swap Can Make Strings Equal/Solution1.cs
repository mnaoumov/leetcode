using JetBrains.Annotations;

namespace LeetCode.Problems._1790_Check_if_One_String_Swap_Can_Make_Strings_Equal;

/// <summary>
/// https://leetcode.com/submissions/detail/925207698/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool AreAlmostEqual(string s1, string s2) =>
        s1.Zip(s2, (letter1, letter2) => (letter1, letter2)).Count(x => x.letter1 != x.letter2) <= 2;
}
