namespace LeetCode.Problems._3138_Minimum_Length_of_Anagram_Concatenation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-396/submissions/detail/1249565136/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinAnagramLength(string s)
    {
        var n = s.Length;

        for (var length = 1; length <= n; length++)
        {
            if (n % length != 0)
            {
                continue;
            }

            var counts = new Dictionary<char, int>();

            for (var letterIndex = 0; letterIndex < length; letterIndex++)
            {
                var letter = s[letterIndex];
                counts.TryAdd(letter, 0);
                counts[letter]++;
            }

            var isValid = true;

            for (var wordStartIndex = length; wordStartIndex < n; wordStartIndex += length)
            {
                var counts2 = new Dictionary<char, int>();

                for (var letterIndex = 0; letterIndex < length; letterIndex++)
                {
                    var letter = s[wordStartIndex + letterIndex];
                    counts2.TryAdd(letter, 0);
                    counts2[letter]++;

                    if (counts2[letter] <= counts.GetValueOrDefault(letter, 0))
                    {
                        continue;
                    }

                    isValid = false;
                    break;
                }

                if (!isValid)
                {
                    break;
                }
            }

            if (isValid)
            {
                return length;
            }
        }

        throw new InvalidOperationException();
    }
}
