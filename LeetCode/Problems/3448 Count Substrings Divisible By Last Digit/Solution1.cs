namespace LeetCode.Problems._3448_Count_Substrings_Divisible_By_Last_Digit;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long CountSubstrings(string s)
    {
        var n = s.Length;
        var counts = new Dictionary<(int digit, int mod), int>();

        for (var digit = 1; digit <= 9; digit++)
        {
            counts[(digit, 0)] = 1;
        }

        const int lcm = 2520;
        var num = 0;
        var ans = 0L;
        var lastResult = 0;

        for (var i = 0; i < n; i++)
        {
            var numDigit = s[i] - '0';
            num = (num * 10 + numDigit) % lcm;

            for (var digit = 1; digit <= 9; digit++)
            {
                var key = (digit, num % digit);
                counts.TryAdd(key, 0);
                counts[key]++;
            }

            var key2 = (numDigit, num % numDigit);
            lastResult = counts[key2] - 1;
            ans += lastResult;
        }

        return ans;
    }
}
