using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._1328_Break_a_Palindrome;

/// <summary>
/// https://leetcode.com/submissions/detail/819083914/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const char FirstPossibleLetter = 'a';
    private const char SecondPossibleLetter = 'b';

    public string BreakPalindrome(string palindrome)
    {
        if (palindrome.Length == 1)
        {
            return "";
        }

        var firstCandidate = Enumerable.Range(0, palindrome.Length)
            .Cast<int?>()
            .FirstOrDefault(i => palindrome[i!.Value] != FirstPossibleLetter);

        if (firstCandidate == null || palindrome.Length % 2 == 1 && firstCandidate == palindrome.Length / 2)
        {
            return ReplaceLetter(palindrome.Length - 1, SecondPossibleLetter);
        }
        else
        {
            return ReplaceLetter((int) firstCandidate, FirstPossibleLetter);
        }

        string ReplaceLetter(int index, char letter) => palindrome.Remove(index, 1).Insert(index, new string(new[] { letter }));
    }
}