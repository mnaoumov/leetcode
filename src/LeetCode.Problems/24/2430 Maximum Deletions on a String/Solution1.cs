namespace LeetCode.Problems._2430_Maximum_Deletions_on_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/898813927/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int DeleteString(string s)
    {
        var letterIndicesMap = new Dictionary<char, List<int>>();

        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];

            if (!letterIndicesMap.ContainsKey(letter))
            {
                letterIndicesMap[letter] = new List<int>();
            }

            letterIndicesMap[letter].Add(i);
        }

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == -1)
            {
                return 0;
            }

            var letter = s[index];
            var indices = letterIndicesMap[letter];
            var indexOfIndex = indices.BinarySearch(index);

            if (index < s.Length - 1)
            {
                var result = -1;

                for (var nextIndexOfIndex = indexOfIndex + 1; nextIndexOfIndex < indices.Count; nextIndexOfIndex++)
                {
                    var nextIndex = indices[nextIndexOfIndex];

                    if (nextIndex > 2 * index + 1)
                    {
                        break;
                    }

                    var previousStartIndex = 2 * index + 1 - nextIndex;

                    if (s[(index + 1)..(nextIndex + 1)] != s[previousStartIndex..(index + 1)])
                    {
                        continue;
                    }

                    var previousResult = recursiveFunc(previousStartIndex - 1);

                    if (previousResult != -1)
                    {
                        result = Math.Max(result, 1 + previousResult);
                    }
                }

                return result;
            }
            else
            {
                var result = 1;

                for (var i = 0; i < s.Length; i++)
                {
                    var previousResult = recursiveFunc(i - 1);

                    if (previousResult != -1)
                    {
                        result = Math.Max(result, 1 + previousResult);
                    }
                }

                return result;
            }
        });

        return dp.GetOrCalculate(s.Length - 1);
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
