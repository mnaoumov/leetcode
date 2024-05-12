using JetBrains.Annotations;

namespace LeetCode._0854_K_Similar_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/885802425/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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

            if (letter == default)
            {
                return result;
            }

            var currentCycleLetters = new HashSet<char>();

            result += GetCycleLength(letter, 0) - 1;
            continue;

            int GetCycleLength(char cycleLetter, int currentCycleLength)
            {
                if (cycleLetter == letter && currentCycleLength > 0)
                {
                    return currentCycleLength;
                }

                const int invalidCycle = -1;

                if (!currentCycleLetters.Add(cycleLetter))
                {
                    return invalidCycle;
                }

                foreach (var index1 in indicesMap1[cycleLetter].ToArray())
                {
                    indicesMap1[cycleLetter].Remove(index1);
                    var nextCycleLength = GetCycleLength(s2[index1], currentCycleLength + 1);

                    if (nextCycleLength != invalidCycle)
                    {
                        return nextCycleLength;
                    }

                    indicesMap1[cycleLetter].Add(index1);
                }

                return invalidCycle;
            }
        }
    }
}
