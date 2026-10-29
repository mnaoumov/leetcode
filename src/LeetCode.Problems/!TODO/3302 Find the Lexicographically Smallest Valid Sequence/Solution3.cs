namespace LeetCode.Problems._3302_Find_the_Lexicographically_Smallest_Valid_Sequence;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] ValidSequence(string word1, string word2)
    {
        var impossible = Array.Empty<int>();

        var dp = new DynamicProgramming<int, int[]>((index, getOrCalculate) =>
        {
            if (index == word1.Length)
            {
                return impossible;
            }

            var nextSequence = getOrCalculate(index + 1);

            if (nextSequence.Length < word2.Length && word1[index] == word2[^(nextSequence.Length + 1)])
            {
                return nextSequence.Prepend(index).ToArray();
            }

            if (nextSequence.Length > 0 && word1[index] == word2[nextSequence[0]])
            {
                var list = new List<int> { index };

                for (var i = 0; i < nextSequence.Length; i++)
                {
                    //if (word2[nextSequence[i]] == word2[i+1])
                }

                //return get
            }

            return Array.Empty<int>();
        });

        return dp.GetOrCalculate(0).ToArray();
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
