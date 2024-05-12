using JetBrains.Annotations;

namespace LeetCode.Problems._0520_Detect_Capital;

/// <summary>
/// https://leetcode.com/submissions/detail/869479295/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool DetectCapitalUse(string word)
    {
        if (word.Length == 1)
        {
            return true;
        }

        var isFirstUpper = char.IsUpper(word[0]);
        var isSecondUpper = char.IsUpper(word[1]);
        var doOtherLettersHaveSameCaseAsSecond = word.Skip(2).All(letter => char.IsUpper(letter) == isSecondUpper);

        return doOtherLettersHaveSameCaseAsSecond && (isFirstUpper || !isSecondUpper);
    }
}
