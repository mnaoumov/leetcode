using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0171_Excel_Sheet_Column_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/193814896/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int TitleToNumber(string s)
    {
        const int lettersCount = 26;
        return s.Aggregate(0, (current, letter) => current * lettersCount + TitleToNumber(letter));
    }

    private static int TitleToNumber(char letter)
    {
        const char firstTitleLetter = 'A';
        const int firstTitleNumber = 1;
        return letter - firstTitleLetter + firstTitleNumber;
    }
}
