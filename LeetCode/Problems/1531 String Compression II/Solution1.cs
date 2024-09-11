using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._1531_String_Compression_II;

/// <summary>
/// https://leetcode.com/submissions/detail/823309721/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetLengthOfOptimalCompression(string s, int k)
    {
        var lettersGroup = new LetterGroup(s);

        var dp = new Dictionary<(int letterIndex, int lettersToRemoveCount), LetterGroup>();

        var bestLetterGroup = GetBestLetterGroup(0, k);
        return bestLetterGroup.GetCompressedLength();

        LetterGroup GetBestLetterGroup(int letterIndex, int lettersToRemoveCount)
        {
            var key = (letterIndex, lettersToRemoveCount);
            if (!dp.TryGetValue(key, out var result))
            {
                dp[key] = result = Calculate();
            }

            return result;

            LetterGroup Calculate()
            {
                if (lettersToRemoveCount == 0)
                {
                    return lettersGroup.TrimAt(letterIndex);
                }

                if (letterIndex >= lettersGroup.Count)
                {
                    return LetterGroup.Wrong();
                }

                var letterCount = lettersGroup.GetCount(letterIndex);
                var minLength = int.MaxValue;
                var minGroup = LetterGroup.Wrong();
                for (var i = 0; i <= Math.Min(lettersToRemoveCount, letterCount); i++)
                {
                    var tailGroup = GetBestLetterGroup(letterIndex + 1, lettersToRemoveCount - i);
                    if (tailGroup.IsWrong)
                    {
                        continue;
                    }

                    var @group = tailGroup.Prepend(lettersGroup.GetLetter(letterIndex), letterCount - i);
                    var length = @group.GetCompressedLength();
                    if (length <= minLength)
                    {
                        minLength = length;
                        minGroup = @group;
                    }
                }

                return minGroup;
            }
        }
    }

    private class LetterGroup
    {
        private readonly List<LetterCountPair> _pairs = new();

        public LetterGroup(string s)
        {
            foreach (var letter in s)
            {
                if (_pairs.Count == 0 || _pairs[^1].Letter != letter)
                {
                    _pairs.Add(new LetterCountPair
                    {
                        Letter = letter,
                        Count = 1
                    });
                }
                else
                {
                    _pairs[^1].Count++;
                }
            }
        }

        public int Count => _pairs.Count;

        public int GetCompressedLength() => _pairs.Select(pair => pair.ToString().Length).Sum();

        public int GetCount(int letterIndex) => _pairs[letterIndex].Count;

        public char GetLetter(int letterIndex) => _pairs[letterIndex].Letter;

        public LetterGroup Prepend(char letter, int count)
        {
            var copy = TrimAt(0);

            if (count == 0)
            {
                return copy;
            }


            if (copy.Count > 0 && copy._pairs[0].Letter == letter)
            {
                copy._pairs[0].Count += count;
            }
            else
            {
                copy._pairs.Insert(0, new LetterCountPair
                {
                    Letter = letter,
                    Count = count
                });
            }

            return copy;
        }

        public LetterGroup TrimAt(int letterIndex)
        {
            var letterGroup = new LetterGroup("");
            letterGroup._pairs.AddRange(_pairs.Skip(letterIndex));
            return letterGroup;
        }

        public static LetterGroup Wrong()
        {
            return new LetterGroup("") { IsWrong = true };
        }

        public bool IsWrong { get; [UsedImplicitly] init; }

        public override string ToString() => string.Concat(_pairs.Select(pair => pair.ToString()));
    }

    private class LetterCountPair
    {
        public char Letter { get; init; }
        public int Count { get; set; }

        public override string ToString()
        {
            return Count switch
            {
                0 => "",
                1 => Letter.ToString(),
                _ => $"{Letter}{Count}"
            };
        }
    }
}
