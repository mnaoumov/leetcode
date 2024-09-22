namespace LeetCode.Problems._3298_Count_Substrings_That_Can_Be_Rearranged_to_Contain_a_String_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long ValidSubstringCount(string word1, string word2)
    {
        var ans = 0L;

        var startIndex = 0;

        var missingLetterCounts = new Dictionary<char, int>();

        foreach (var letter in word2)
        {
            missingLetterCounts.TryAdd(letter, 0);
            missingLetterCounts[letter]++;
        }

        var missingLettersTotal = word2.Length;

        //for (var endIndex = 0; endIndex < word1.Length; endIndex++)
        //{
        //    var letter = word1[endIndex];

        //    if (!missingLetterCounts.ContainsKey(letter))
        //    {
        //        continue;
        //    }

        //    missingLetterCounts[letter]--;
        //    if (missingLetterCounts[letter] >= 0)
        //    {
        //        missingLettersTotal--;
        //    }

        //    while (missingLettersTotal == 0)
        //    {
        //        ans += word1.Length - endIndex;

        //        var oldLetter = word1[startIndex];
        //        startIndex++;

        //        if (!missingLetterCounts.ContainsKey(oldLetter))
        //        {
        //            continue;
        //        }

        //        missingLetterCounts[oldLetter]++;

        //        if (missingLetterCounts[oldLetter] <= 0)
        //        {
        //            continue;
        //        }

        //        missingLettersTotal = 1;
        //    }
        //}

        return ans;
    }
}
