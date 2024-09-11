using System.Text;

namespace LeetCode.Problems._0168_Excel_Sheet_Column_Title;

/// <summary>
/// https://leetcode.com/submissions/detail/879060384/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ConvertToTitle(int columnNumber)
    {
        var sb = new StringBuilder();
        const int alphabetLetterCount = 26;

        while (columnNumber > 0)
        {
            var letterIndex = columnNumber % alphabetLetterCount;

            if (letterIndex == 0)
            {
                letterIndex = alphabetLetterCount;
            }

            var letter = (char) ('A' + (letterIndex - 1));
            sb.Insert(0, letter);
            columnNumber = (columnNumber - letterIndex) / alphabetLetterCount;
        }

        return sb.ToString();
    }
}
