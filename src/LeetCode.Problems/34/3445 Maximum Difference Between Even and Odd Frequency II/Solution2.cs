namespace LeetCode.Problems._3445_Maximum_Difference_Between_Even_and_Odd_Frequency_II;

/// <summary>
/// https://leetcode.com/problems/maximum-difference-between-even-and-odd-frequency-ii/submissions/1660407475/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxDifference(string s, int k)
    {
        var n = s.Length;
        const int digitsCount = 5;
        var entryIndices = new Dictionary<Entry, List<int>>();

        for (var digit1 = 0; digit1 < digitsCount; digit1++)
        {
            for (var digit2 = digit1 + 1; digit2 < digitsCount; digit2++)
            {
                entryIndices.Add(new Entry(digit1, digit2, true, true), new List<int> { 0 });
            }
        }

        var frequencies = new int[digitsCount, n + 1];
        var ans = int.MinValue;

        for (var i = 0; i < n; i++)
        {
            for (var otherDigit = 0; otherDigit < digitsCount; otherDigit++)
            {
                frequencies[otherDigit, i + 1] = frequencies[otherDigit, i];
            }
            var digit = s[i] - '0';
            frequencies[digit, i + 1]++;

            for (var otherDigit = 0; otherDigit < digitsCount; otherDigit++)
            {
                if (otherDigit == digit)
                {
                    continue;
                }

                var digit1 = Math.Min(digit, otherDigit);
                var digit2 = Math.Max(digit, otherDigit);
                var parity1 = frequencies[digit1, i + 1] % 2 == 0;
                var parity2 = frequencies[digit2, i + 1] % 2 == 0;

                var entry = new Entry(digit1, digit2, parity1, parity2);

                entryIndices.TryAdd(entry, new List<int>());
                entryIndices[entry].Add(i + 1);

                var previousEntries = new[]
                {
                    entry with { Parity1 = entry.Parity1 ^ true },
                    entry with { Parity2 = entry.Parity2 ^ true }
                };

                foreach (var previousEntry in previousEntries)
                {
                    if (!entryIndices.TryGetValue(previousEntry, out var indices))
                    {
                        continue;
                    }

                    foreach (var index in indices)
                    {
                        if (i - index < k - 1)
                        {
                            break;
                        }

                        var frequency1 = frequencies[digit1, i + 1] - frequencies[digit1, index];
                        var frequency2 = frequencies[digit2, i + 1] - frequencies[digit2, index];

                        if (frequency1 == 0 || frequency2 == 0)
                        {
                            break;
                        }

                        var diff = frequency1 % 2 == 0 ? frequency2 - frequency1 : frequency1 - frequency2;
                        ans = Math.Max(ans, diff);
                    }
                }
            }
        }

        return ans;
    }

    private record Entry(int Digit1, int Digit2, bool Parity1, bool Parity2);
}
