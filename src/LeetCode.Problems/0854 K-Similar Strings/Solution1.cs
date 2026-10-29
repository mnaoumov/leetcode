namespace LeetCode.Problems._0854_K_Similar_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/885780673/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int KSimilarity(string s1, string s2)
    {
        var possibleLetters = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        var indicesMap1 = possibleLetters.ToDictionary(letter => letter, _ => new HashSet<int>());

        var n = s1.Length;

        var lettersToSwapCount = 0;

        for (var i = 0; i < n; i++)
        {
            var letter1 = s1[i];
            var letter2 = s2[i];

            if (letter1 == letter2)
            {
                continue;
            }

            indicesMap1[letter1].Add(i);
            lettersToSwapCount++;
        }

        if (lettersToSwapCount == 0)
        {
            return 0;
        }

        var result = 0;

        while (true)
        {
            var letter = possibleLetters.FirstOrDefault(letter => indicesMap1[letter].Any());

            if (letter == 0)
            {
                return result;
            }

            result--;

            var cycleLetter = letter;

            do
            {
                var index1 = indicesMap1[cycleLetter].First();
                indicesMap1[cycleLetter].Remove(index1);
                result++;
                cycleLetter = s2[index1];
            } while (cycleLetter != letter);
        }
    }
}
