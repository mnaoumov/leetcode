namespace LeetCode.Problems._3723_Maximize_Sum_of_Squares_of_Digits;

/// <summary>
///https://leetcode.com/contest/biweekly-contest-168/problems/maximize-sum-of-squares-of-digits/submissions/1811338712/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public string MaxSumOfSquares(int num, int sum)
    {
        var impossible = (maxScore: 0, maxScoreStr: "");
        const int maxPossibleDigit = 9;

        var dp = new DynamicProgramming<(int digitsCount, int digitsSum), (int maxScore, string maxScoreStr)>((key, getOrCalculate) =>
        {
            var (digitsCount, digitsSum) = key;

            if (digitsSum > digitsCount * maxPossibleDigit)
            {
                return impossible;
            }

            if (digitsCount == 1)
            {
                return (digitsSum * digitsSum, maxScoreStr: digitsSum.ToString());
            }

            var minDigit = digitsCount == num ? 1 : 0;
            var maxDigit = Math.Min(maxPossibleDigit, digitsSum);

            var ans = impossible;

            for (var digit = maxDigit; digit >= minDigit; digit--)
            {
                var next = getOrCalculate((digitsCount - 1, digitsSum - digit));

                if (next == impossible)
                {
                    continue;
                }

                var candidate = (maxScore: digit * digit + next.maxScore, maxScoreStr: digit + next.maxScoreStr);

                if (candidate.CompareTo(ans) < 0)
                {
                    continue;
                }

                ans = candidate;
                break;
            }

            return ans;
        });

        return dp.GetOrCalculate((num, sum)).maxScoreStr;
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
