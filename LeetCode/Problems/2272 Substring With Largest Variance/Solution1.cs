namespace LeetCode.Problems._2272_Substring_With_Largest_Variance;

/// <summary>
/// https://leetcode.com/submissions/detail/990501363/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestVariance(string s)
    {
        var counts = new Dictionary<char, int>();

        foreach (var letter in s)
        {
            counts.TryAdd(letter, 0);
            counts[letter]++;
        }

        var ans = 0;

        foreach (var majorLetter in counts.Keys)
        {
            foreach (var minorLetter in counts.Keys.Except(new[] { majorLetter }))
            {
                var majorLetterCount = 0;
                var minorLetterCount = 0;
                var minorLetterLeftCount = counts[minorLetter];

                foreach (var letter in s)
                {
                    if (letter == majorLetter)
                    {
                        majorLetterCount++;
                    }
                    else if (letter == minorLetter)
                    {
                        minorLetterCount++;
                        minorLetterLeftCount--;
                    }

                    if (minorLetterCount > 0)
                    {
                        ans = Math.Max(ans, majorLetterCount - minorLetterCount);
                    }

                    if (majorLetterCount >= minorLetterCount || minorLetterLeftCount == 0)
                    {
                        continue;
                    }

                    majorLetterCount = 0;
                    minorLetterCount = 0;
                }
            }
        }

        return ans;
    }
}
