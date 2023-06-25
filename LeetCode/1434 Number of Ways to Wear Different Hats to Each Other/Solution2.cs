using JetBrains.Annotations;

namespace LeetCode._1434_Number_of_Ways_to_Wear_Different_Hats_to_Each_Other;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberWays(IList<IList<int>> hats)
    {
        var n = hats.Count;

        var hatsPeopleMap = new Dictionary<int, List<int>>();

        for (var person = 0; person < hats.Count; person++)
        {
            foreach (var hat in hats[person])
            {
                hatsPeopleMap.TryAdd(hat, new List<int>());
                hatsPeopleMap[hat].Add(person);
            }
        }

        var dp = new DynamicProgramming<(int personIndex, long takenHatsMask), ModNumber>((key, recursiveFunc) =>
        {
            var (personIndex, takenHatsMask) = key;

            if (personIndex == n)
            {
                return 1;
            }

            return hats[personIndex].Where(hat => (takenHatsMask & 1L << hat) == 0)
                .Aggregate<int, ModNumber>(0,
                    (sum, hat) => sum + recursiveFunc((personIndex + 1, takenHatsMask | 1L << hat)));
        });

        return dp.GetOrCalculate((0, 0L));
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

        private ModNumber(int value) => _value = value % Modulo;
        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);
    }
}


