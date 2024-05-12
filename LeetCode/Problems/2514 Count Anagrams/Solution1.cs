using JetBrains.Annotations;

namespace LeetCode._2514_Count_Anagrams;

/// <summary>
/// https://leetcode.com/submissions/detail/864953654/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private static readonly DynamicProgramming<int, ModuloNumber> FactorialDp =
        new(
            (number, recursiveFunc) =>
            {
                if (number == 0)
                {
                    return new ModuloNumber(1);
                }

                return recursiveFunc(number - 1) * new ModuloNumber(number);
            });

    public int CountAnagrams(string s)
    {
        var words = s.Split(' ');
        return words.Aggregate(new ModuloNumber(1), (current, word) => current * CountWordAnagrams(word)).IntValue;
    }

    private static ModuloNumber CountWordAnagrams(string word)
    {
        return word.GroupBy(letter => letter).Select(g => g.Count()).Aggregate(Factorial(word.Length),
            (current, letterCount) => current / Factorial(letterCount));
    }

    private static ModuloNumber Factorial(int n) => FactorialDp.GetOrCalculate(n);

    private class ModuloNumber
    {
        private static readonly DynamicProgramming<long, ModuloNumber> InverseDp =
            new(
                (value, _) =>
                {
                    if (value == 0)
                    {
                        throw new InvalidOperationException();
                    }

                    var a = Modulo;
                    var b = value;

                    // a = Modulo * ua + value * va
                    // b = Modulo * ub + value * vb

                    long ua = 1;
                    long va = 0;
                    long ub = 0;
                    long vb = 1;

                    while (b > 0)
                    {
                        var r = a % b;
                        var q = a / b;
                        (a, b, ua, va, ub, vb) = (b, r, ub, vb, ua - q * va, va - q * vb);
                    }

                    return new ModuloNumber(va < 0 ? va + Modulo : va);
                });


        private const long Modulo = 1_000_000_007;
        private long Value { get; }
        public int IntValue => (int) Value;

        public ModuloNumber(long value)
        {
            Value = value % Modulo;
        }

        public override string ToString() => Value.ToString();

        public static ModuloNumber operator *(ModuloNumber left, ModuloNumber right) => new(left.Value * right.Value);
        public static ModuloNumber operator /(ModuloNumber left, ModuloNumber right) => left * Inverse(right);

        private static ModuloNumber Inverse(ModuloNumber number) => InverseDp.GetOrCalculate(number.Value);
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
