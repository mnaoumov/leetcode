namespace LeetCode.Problems._0788_Rotated_Digits;

/// <summary>
/// https://leetcode.com/problems/rotated-digits/submissions/1993687646/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int RotatedDigits(int n)
    {
        var sameRotated = new HashSet<int> { 0, 1, 8 };
        var otherRotated = new HashSet<int> { 2, 5, 6, 9 };

        var dp = new DynamicProgramming<(int maxNumber, bool shouldDiffer), int>((key, getOrCalculate) =>
        {
            var (maxNumber, shouldDiffer) = key;

            if (maxNumber < 10)
            {
                return shouldDiffer
                    ? otherRotated.Count(digit => digit <= maxNumber)
                    : otherRotated.Concat(sameRotated).Count(digit => digit <= maxNumber);
            }

            var powerOfTen = 1;

            while (powerOfTen * 10 <= maxNumber)
            {
                powerOfTen *= 10;
            }

            var maxDigit = maxNumber / powerOfTen;

            var ans = 0;

            for (var digit = 0; digit <= maxDigit; digit++)
            {
                var nextMaxNumber = digit == maxDigit ? maxNumber - maxDigit * powerOfTen : powerOfTen - 1;

                if (sameRotated.Contains(digit))
                {
                    ans += getOrCalculate((nextMaxNumber, shouldDiffer));
                }
                else if (otherRotated.Contains(digit))
                {
                    ans += getOrCalculate((nextMaxNumber, false));
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((n, true));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
