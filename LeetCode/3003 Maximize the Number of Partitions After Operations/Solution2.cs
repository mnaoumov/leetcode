using JetBrains.Annotations;

namespace LeetCode._3003_Maximize_the_Number_of_Partitions_After_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1139203320/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxPartitionsAfterOperations(string s, int k)
    {
        var n = s.Length;

        var dp = new DynamicProgramming<(int index, bool canChange, char changedFirstLetter), int>((key, recursiveFunc) =>
        {
            var (index, canChange, changedFirstLetter) = key;

            var uniqueLettersSet = new HashSet<char>();

            var ans = 1;

            for (var i = index; i < n; i++)
            {
                if (canChange)
                {
                    if (uniqueLettersSet.Count == k)
                    {
                        for (var newLetter = 'a'; newLetter <= 'z'; newLetter++)
                        {
                            if (uniqueLettersSet.Contains(newLetter) || s[i] == newLetter)
                            {
                                continue;
                            }

                            ans = Math.Max(ans, 1 + recursiveFunc((i, false, newLetter)));
                        }
                    }

                    if (uniqueLettersSet.Count == k - 1 && i + 1 < n && !uniqueLettersSet.Contains(s[i + 1]))
                    {
                        ans = Math.Max(ans, 1 + recursiveFunc((i + 1, false, s[i + 1])));
                    }
                }

                uniqueLettersSet.Add(i == index ? changedFirstLetter : s[i]);

                if (uniqueLettersSet.Count <= k)
                {
                    continue;
                }

                ans = Math.Max(ans, 1 + recursiveFunc((i, canChange, s[i])));
                break;
            }

            return ans;
        });

        const int maxLettersCount = 26;
        return dp.GetOrCalculate((0, k < maxLettersCount, s[0]));
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
