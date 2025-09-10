using System.Numerics;

namespace LeetCode.Problems._3665_Twisted_Mirror_Path_Count;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-164/problems/twisted-mirror-path-count/submissions/1753965529/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int UniquePaths(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var dp = new DynamicProgramming<(int row, int column), ModNumber>((key, recursiveFunc) =>
        {
            var (row, column) = key;
            if (row == m - 1 && column == n - 1)
            {
                return 1;
            }

            ModNumber ans = 0;

            foreach (var initialIsGoingDown in new[] { true, false })
            {
                var nextRow = row;
                var nextColumn = column;
                var isGoingDown = initialIsGoingDown;

                while (true)
                {
                    if (isGoingDown)
                    {
                        nextRow++;
                    }
                    else
                    {
                        nextColumn++;
                    }

                    if (nextRow >= m || nextColumn >= n)
                    {
                        break;
                    }

                    if (grid[nextRow][nextColumn] == 0)
                    {
                        ans += recursiveFunc((nextRow, nextColumn));
                        break;
                    }

                    isGoingDown = !isGoingDown;
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2 == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
