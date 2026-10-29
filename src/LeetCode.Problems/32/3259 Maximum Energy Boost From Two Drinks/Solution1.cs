namespace LeetCode.Problems._3259_Maximum_Energy_Boost_From_Two_Drinks;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-411/submissions/detail/1359787012/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB)
    {
        var n = energyDrinkA.Length;

        var dp = new DynamicProgramming<(int index, bool isDrinkA), int>((key, recursiveFunc) =>
        {
            var (index, isDrinkA) = key;

            if (index == n)
            {
                return 0;
            }

            var currentBoost = isDrinkA ? energyDrinkA[index] : energyDrinkB[index];
            return Math.Max(currentBoost + recursiveFunc((index + 1, isDrinkA)), recursiveFunc((index + 1, !isDrinkA)));
        });

        return Math.Max(dp.GetOrCalculate((0, true)), dp.GetOrCalculate((0, false)));
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
