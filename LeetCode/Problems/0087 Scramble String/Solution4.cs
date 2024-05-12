using JetBrains.Annotations;

namespace LeetCode.Problems._0087_Scramble_String;

/// <summary>
/// https://leetcode.com/submissions/detail/829073461/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool IsScramble(string s1, string s2)
    {
        var letterCountDict1 = PrepareLetterCountDict(s1);
        var letterCountDict2 = PrepareLetterCountDict(s2);

        var letters = letterCountDict1[0].Keys;

        var dp = new Dictionary<(int start1, int start2, int length), bool>();

        return Get(0, 0, s1.Length);

        bool Get(int start1, int start2, int length)
        {
            var key = (start1, start2, length);
            if (!dp.TryGetValue(key, out var result))
            {
                dp[key] = result = Calculate();
            }

            return result;

            bool Calculate()
            {
                if (letters.Any(letter => GetLetterCount(letter, letterCountDict1, start1, length) !=
                                          GetLetterCount(letter, letterCountDict2, start2, length)))
                {
                    return false;
                }

                var areEqual = true;

                for (var i = 0; i < length; i++)
                {
                    if (s1[start1 + i] == s2[start2 + i])
                    {
                        continue;
                    }

                    areEqual = false;
                    break;
                }

                if (areEqual)
                {
                    return true;
                }

                for (var partitionLength = 1; partitionLength <= length - 1; partitionLength++)
                {
                    if (Get(start1, start2, partitionLength)
                        && Get(start1 + partitionLength, start2 + partitionLength, length - partitionLength))
                    {
                        return true;
                    }

                    if (Get(start1, start2 + length - partitionLength, partitionLength)
                        && Get(start1 + partitionLength, start2, length - partitionLength))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }

    private static int GetLetterCount(char letter, IReadOnlyList<Dictionary<char, int>> countDict, int start, int length) =>
        GetLetterCount(letter, countDict, start + length - 1) - GetLetterCount(letter, countDict, start - 1);

    private static int GetLetterCount(char letter, IReadOnlyList<Dictionary<char, int>> countDict, int end) =>
        end >= 0 && countDict[end].TryGetValue(letter, out var count) ? count : 0;

    private static Dictionary<char, int>[] PrepareLetterCountDict(string str)
    {
        var result = new Dictionary<char, int>[str.Length];

        for (var i = 0; i < str.Length; i++)
        {
            var letter = str[i];
            for (var j = i; j < str.Length; j++)
            {
                var dict = result[j];

                if (dict == null!)
                {
                    result[j] = dict = new Dictionary<char, int>();
                }

                dict.TryAdd(letter, 0);

                dict[letter]++;
            }
        }


        return result;
    }
}
