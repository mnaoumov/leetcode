using JetBrains.Annotations;

namespace LeetCode.Problems._1832_Check_if_the_Sentence_Is_Pangram;

/// <summary>
/// https://leetcode.com/submissions/detail/824472751/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckIfPangram(string sentence)
    {
        var uniqueCharacters = new HashSet<char>(sentence);
        const int alphabetLettersCount = 26;
        return uniqueCharacters.Count == alphabetLettersCount;
    }
}
