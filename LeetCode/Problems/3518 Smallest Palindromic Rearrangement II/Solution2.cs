using System.Numerics;

namespace LeetCode.Problems._3518_Smallest_Palindromic_Rearrangement_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-445/problems/smallest-palindromic-rearrangement-ii/submissions/1605171495/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public string SmallestPalindrome(string s, int k)
    {
        if (s.Length == 1)
        {
            return k == 1 ? s : "";
        }

        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        var m = s.Length / 2;
        var factorials = new BigInteger[m + 1];
        factorials[0] = 1;

        for (var i = 1; i <= m; i++)
        {
            factorials[i] = factorials[i - 1] * i;
        }

        var sortedLetters = counts.Keys.OrderBy(x => x).ToList();
        var middleLetter = counts.FirstOrDefault(kvp => kvp.Value % 2 == 1).Key;
        const char noMiddleLetter = '\0';
        if (middleLetter != noMiddleLetter)
        {
            counts[middleLetter]--;
        }

        return GetPalindrome(k).palindrome;

        (string palindrome, BigInteger totalCount) GetPalindrome(BigInteger index)
        {
            var totalCount = factorials[counts.Values.Sum() / 2];
            totalCount = counts.Values.Aggregate(totalCount, (current, count) => current / factorials[count / 2]);

            if (index > totalCount)
            {
                return ("", totalCount);
            }

            foreach (var letter in sortedLetters.Where(letter => counts[letter] > 0))
            {
                counts[letter] -= 2;
                var (middlePalindrome, middleTotalCount) = GetPalindrome(index);

                if (middlePalindrome == "")
                {
                    index -= middleTotalCount;
                    counts[letter] += 2;
                }
                else
                {
                    if (middlePalindrome[0] == noMiddleLetter)
                    {
                        middlePalindrome = middleLetter == noMiddleLetter ? "" : middleLetter.ToString();
                    }

                    return (letter + middlePalindrome + letter, totalCount);
                }
            }

            return (noMiddleLetter.ToString(), totalCount);
        }
    }
}
