using System.Text;
using JetBrains.Annotations;

namespace LeetCode._3003_Maximize_the_Number_of_Partitions_After_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1139186192/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxPartitionsAfterOperations(string s, int k)
    {
        var sb = new StringBuilder(s);
        var n = s.Length;

        var dp = new DynamicProgramming<(int index, bool canChange), int>((key, recursiveFunc) =>
        {
            var (index, canChange) = key;

            var uniqueLettersSet = new HashSet<int>();

            var ans = 1;

            for (var i = index; i < n; i++)
            {
                if (uniqueLettersSet.Count == k && canChange && k < 26)
                {
                    for (var newLetter = 'a'; newLetter <= 'z'; newLetter++)
                    {
                        if (uniqueLettersSet.Contains(newLetter) || s[i] == newLetter)
                        {
                            continue;
                        }

                        sb[i] = newLetter;
                        ans = Math.Max(ans, 1 + recursiveFunc((i, false)));
                        sb[i] = s[i];
                    }
                }

                uniqueLettersSet.Add(sb[i]);

                if (uniqueLettersSet.Count <= k)
                {
                    continue;
                }

                ans = Math.Max(ans, 1 + recursiveFunc((i, canChange)));
                break;
            }

            return ans;
        });

        return dp.GetOrCalculate((0, true));
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
