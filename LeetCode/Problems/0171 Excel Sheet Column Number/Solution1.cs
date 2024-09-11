

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0171_Excel_Sheet_Column_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/193813878/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TitleToNumber(string s)
    {
        if (s.Length == 1)
        {
            return TitleToNumber(s[0]);
        }

        const int lettersCount = 26;
        return TitleToNumber(s[0]) * lettersCount + TitleToNumber(s[1]);
    }

    private static int TitleToNumber(char c)
    {
        const char firstTitleCharacter = 'A';
        const int firstTitleNumber = 1;
        return c - firstTitleCharacter + firstTitleNumber;
    }
}
