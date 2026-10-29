using System.Numerics;

namespace LeetCode.Problems._2430_Maximum_Deletions_on_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/898829219/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int DeleteString(string s)
    {
        const int modulo = 1_000_000_007;
        const long prime = 347L;
        var primeInverse = BigInteger.ModPow(prime, modulo - 2, modulo);
        var n = s.Length;
        var inversePrimePowers = new int[n];
        inversePrimePowers[0] = 1;

        for (var i = 1; i < n; i++)
        {
            inversePrimePowers[i] = (int) (inversePrimePowers[i - 1] * primeInverse % modulo);
        }

        var hashes = new int[n];

        for (var i = 0; i < n; i++)
        {
            hashes[i] = (int) (((i > 0 ? hashes[i - 1] : 0) * prime + (s[i] - 'a')) % modulo);
        }

        var letterIndicesMap = new Dictionary<char, List<int>>();

        for (var i = 0; i < n; i++)
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

            if (index < n - 1)
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

                    if (!AreSubstringsEqual(index, nextIndex))
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

                for (var i = 0; i < n; i++)
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

        return dp.GetOrCalculate(n - 1);

        bool AreSubstringsEqual(int endIndex1, int endIndex2)
        {
            var length = endIndex2 - endIndex1;
            var startIndex1 = endIndex1 - length + 1;
            var startIndex2 = endIndex1 + 1;

            var hash1 = GetHash(startIndex1, endIndex1);
            var hash2 = GetHash(startIndex2, endIndex2);

            return hash1 == hash2 && AreSubstringsEqualCompareByLetters(s, endIndex1, endIndex2);
        }

        int GetHash(int startIndex, int endIndex)
        {
            var hash = hashes[endIndex];

            if (startIndex == 0)
            {
                return hash;
            }

            hash = (hashes[endIndex] - hashes[startIndex - 1]) % modulo;
            hash = (hash + modulo) % modulo;
            hash = (int) (hash * (long) inversePrimePowers[startIndex] % modulo);

            return hash;
        }
    }

    private static bool AreSubstringsEqualCompareByLetters(string s, int endIndex1, int endIndex2)
    {
        var index1 = endIndex1;
        var index2 = endIndex2;

        while (index2 > endIndex1)
        {
            if (s[index2] != s[index1])
            {
                return false;
            }

            index2--;
            index1--;
        }

        return true;
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
