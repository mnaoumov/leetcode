

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._1531_String_Compression_II;

/// <summary>
/// https://leetcode.com/submissions/detail/823312033/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int GetLengthOfOptimalCompression(string s, int k)
    {
        var lettersGroup = new LetterGroup(s);

        var dp = new Dictionary<(int letterIndex, int lettersToRemoveCount), List<LetterGroup>>();

        var bestLetterGroup = GetBestLetterGroup(0, k).First();
        return bestLetterGroup.GetCompressedLength();

        List<LetterGroup> GetBestLetterGroup(int letterIndex, int lettersToRemoveCount)
        {
            var key = (letterIndex, lettersToRemoveCount);
            if (!dp.TryGetValue(key, out var result))
            {
                dp[key] = result = Calculate();
            }

            return result;

            List<LetterGroup> Calculate()
            {
                if (lettersToRemoveCount == 0)
                {
                    return new List<LetterGroup> { lettersGroup.TrimAt(letterIndex) };
                }

                if (letterIndex >= lettersGroup.Count)
                {
                    return new List<LetterGroup>();
                }

                var letterCount = lettersGroup.GetCount(letterIndex);
                var minLength = int.MaxValue;
                var minGroups = new List<LetterGroup>();
                for (var i = 0; i <= Math.Min(lettersToRemoveCount, letterCount); i++)
                {
                    var tailGroups = GetBestLetterGroup(letterIndex + 1, lettersToRemoveCount - i);

                    foreach (var tailGroup in tailGroups)
                    {
                        var @group = tailGroup.Prepend(lettersGroup.GetLetter(letterIndex), letterCount - i);
                        var length = @group.GetCompressedLength();
                        if (length < minLength)
                        {
                            minLength = length;
                            minGroups.Clear();
                            minGroups.Add(@group);
                        }
                        else if (length == minLength)
                        {
                            minGroups.Add(@group);
                        }
                    }

                }

                return minGroups;
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
