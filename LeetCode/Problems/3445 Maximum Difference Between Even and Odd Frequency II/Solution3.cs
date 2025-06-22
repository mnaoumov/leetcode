namespace LeetCode.Problems._3445_Maximum_Difference_Between_Even_and_Odd_Frequency_II;

/// <summary>
/// https://leetcode.com/problems/maximum-difference-between-even-and-odd-frequency-ii/submissions/1660417461/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MaxDifference(string s, int k)
    {
        var n = s.Length;
        const int digitsCount = 5;

        var frequenciesTable = new int[digitsCount, n + 1];

        for (var i = 0; i < n; i++)
        {
            for (var otherDigit = 0; otherDigit < digitsCount; otherDigit++)
            {
                frequenciesTable[otherDigit, i + 1] = frequenciesTable[otherDigit, i];
            }
            var digit = s[i] - '0';
            frequenciesTable[digit, i + 1]++;
        }

        var ans = int.MinValue;

        for (var i = 0; i <= n - k; i++)
        {
            for (var j = i + k; j <= n; j++)
            {
                var maxOddFrequency = int.MinValue;
                var minEvenFrequency = int.MaxValue;

                for (var digit = 0; digit < digitsCount; digit++)
                {
                    var frequency = frequenciesTable[digit, j] - frequenciesTable[digit, i];
                    if (frequency == 0)
                    {
                        continue;
                    }

                    if (frequency % 2 == 0)
                    {
                        minEvenFrequency = Math.Min(minEvenFrequency, frequency);
                    }
                    else
                    {
                        maxOddFrequency = Math.Max(maxOddFrequency, frequency);
                    }
                }

                if (maxOddFrequency != int.MinValue && minEvenFrequency != int.MaxValue)
                {
                    ans = Math.Max(ans, maxOddFrequency - minEvenFrequency);
                }
            }
        }

        return ans;
    }
}
