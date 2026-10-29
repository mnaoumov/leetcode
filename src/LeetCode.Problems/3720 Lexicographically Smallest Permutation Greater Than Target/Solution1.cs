using System.Text;

namespace LeetCode.Problems._3720_Lexicographically_Smallest_Permutation_Greater_Than_Target;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-472/problems/lexicographically-smallest-permutation-greater-than-target/submissions/1805564968/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public string LexGreaterPermutation(string s, string target)
    {
        var sourceLetterCounts = s.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        return GetNextPermutation(sourceLetterCounts, new SortedSet<char>(sourceLetterCounts.Keys), target, 0);
    }

    private static string GetNextPermutation(Dictionary<char, int> sourceLetterCounts, SortedSet<char> sortedLetters, string target, int index)
    {
        if (index == target.Length)
        {
            return "";
        }

        var targetLetter = target[index];

        if (sortedLetters.Contains(targetLetter))
        {
            sourceLetterCounts[targetLetter]--;

            if (sourceLetterCounts[targetLetter] == 0)
            {
                sourceLetterCounts.Remove(targetLetter);
                sortedLetters.Remove(targetLetter);
            }

            var next = GetNextPermutation(sourceLetterCounts, sortedLetters, target, index + 1);

            if (next != "")
            {
                return targetLetter + next;
            }

            sourceLetterCounts.TryAdd(targetLetter, 0);
            sourceLetterCounts[targetLetter]++;
            sortedLetters.Add(targetLetter);
        }

        const char maxLetter = 'z';
        const char noLetter = '\0';

        var nextLetter = sortedLetters.GetViewBetween((char) (targetLetter + 1), maxLetter).Min;

        if (nextLetter == noLetter)
        {
            return "";
        }

        var sb = new StringBuilder();
        sb.Append(nextLetter);
        sourceLetterCounts[nextLetter]--;

        foreach (var letter in sortedLetters)
        {
            sb.Append(letter, sourceLetterCounts[letter]);
        }

        sourceLetterCounts[nextLetter]++;

        return sb.ToString();
    }
}
