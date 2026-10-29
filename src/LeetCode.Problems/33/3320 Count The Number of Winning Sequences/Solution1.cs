namespace LeetCode.Problems._3320_Count_The_Number_of_Winning_Sequences;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-419/submissions/detail/1420616816/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountWinningSequences(string s)
    {
        const char noTurn = '\0';
        const char earthGolem = 'E';
        const char waterSerpent = 'W';
        const char fireDragon = 'F';

        var winningPairs = new HashSet<(char, char)>
        {
            (fireDragon, earthGolem),
            (waterSerpent, fireDragon),
            (earthGolem, waterSerpent)
        };

        var n = s.Length;

        var dp = new DynamicProgramming<(int index, int bobScore, char lastBobTurn), ModNumber>((key, recursiveFunc) =>
        {
            var (index, bobScore, lastBobTurn) = key;

            var roundsLeft = n - index;

            if (bobScore + roundsLeft <= 0)
            {
                return 0;
            }

            if (index == n)
            {
                return 1;
            }

            var aliceTurn = s[index];
            ModNumber ans = 0;

            foreach (var bobTurn in new[] { earthGolem, waterSerpent, fireDragon })
            {
                if (bobTurn == lastBobTurn)
                {
                    continue;
                }

                int newBobScore;

                if (bobTurn == aliceTurn)
                {
                    newBobScore = bobScore;
                }
                else if (winningPairs.Contains((bobTurn, aliceTurn)))
                {
                    newBobScore = bobScore + 1;
                }
                else
                {
                    newBobScore = bobScore - 1;
                }

                ans += recursiveFunc((index + 1, newBobScore, bobTurn));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, noTurn));
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

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(long value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();
    }
}
