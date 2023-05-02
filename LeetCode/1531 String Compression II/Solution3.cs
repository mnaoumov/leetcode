using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._1531_String_Compression_II;

/// <summary>
/// https://leetcode.com/submissions/detail/824847181/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int GetLengthOfOptimalCompression(string s, int k)
    {
        var letterCounts = GetLetterCounts();

        var dp = new Dictionary<(int letterIndex, int maxLettersToRemoveCount, char lastLetter, int lastLetterCount), int>();

        return Get(0, k, default(char), 0);

        (char letter, int count)[] GetLetterCounts()
        {
            var list = new List<(char letter, int count)>();

            foreach (var letter in s)
            {
                if (list.Count == 0 || list[^1].letter != letter)
                {
                    list.Add((letter, 1));
                }
                else
                {
                    var lastPair = list[^1];
                    list[^1] = (lastPair.letter, lastPair.count + 1);
                }
            }

            return list.ToArray();
        }

        int Get(int currentLetterIndex, int maxLettersToRemoveCount, char lastLetter, int lastLetterCount)
        {
            var key = (currentLetterIndex, maxLettersToRemoveCount, lastLetter, lastLetterCount);

            if (!dp.TryGetValue(key, out var result))
            {
                dp[key] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (currentLetterIndex >= letterCounts.Length)
                {
                    return 0;
                }

                var currentLetterCountPair = letterCounts[currentLetterIndex];

                var isRepeatingLetter = currentLetterCountPair.letter == lastLetter;

                if (!isRepeatingLetter && maxLettersToRemoveCount == 0)
                {
                    return GetCompressedLength(letterCounts.Skip(currentLetterIndex));
                }

                var minResult = int.MaxValue;

                for (var i = 0; i <= Math.Min(currentLetterCountPair.count, maxLettersToRemoveCount); i++)
                {
                    var newCurrentLetterCount = currentLetterCountPair.count - i;
                    letterCounts[currentLetterIndex] = (currentLetterCountPair.letter, newCurrentLetterCount);

                    var nextLetterResult = Get(
                        currentLetterIndex: currentLetterIndex + 1,
                        maxLettersToRemoveCount: maxLettersToRemoveCount - i,
                        lastLetter: newCurrentLetterCount > 0 ? currentLetterCountPair.letter : lastLetter,
                        lastLetterCount: newCurrentLetterCount > 0 ? newCurrentLetterCount : lastLetterCount);

                    var currentLetterCompressedLength = newCurrentLetterCount > 0 && isRepeatingLetter
                        ? GetCompressedLength(lastLetterCount + newCurrentLetterCount) -
                          GetCompressedLength(lastLetterCount)
                        : GetCompressedLength(newCurrentLetterCount);

                    var newResult = currentLetterCompressedLength + nextLetterResult;
                    minResult = Math.Min(minResult, newResult);

                    letterCounts[currentLetterIndex] = currentLetterCountPair;
                }

                return minResult;
            }
        }
    }

    private static int GetCompressedLength(IEnumerable<(char letter, int count)> letterCounts)
    {
        var result = 0;
        char lastLetter = default;
        var lastCount = 0;
        (char, int) fakeSuffix = (default, 1);
        foreach (var (letter, count) in letterCounts.Concat(new[] { fakeSuffix }))
        {
            if (count == 0)
            {
                continue;
            }

            if (letter != lastLetter)
            {
                result += GetCompressedLength(lastCount);
                lastLetter = letter;
                lastCount = count;
            }
            else
            {
                lastCount += count;
            }
        }

        return result;
    }

    private static int GetCompressedLength(int count)
    {
        return count switch
        {
            0 => 0,
            1 => 1,
            _ => 1 + count.ToString().Length
        };
    }
}
