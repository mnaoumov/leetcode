using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1092_Shortest_Common_Supersequence;

/// <summary>
/// https://leetcode.com/submissions/detail/953705242/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        var dp = new DynamicProgramming<(int index1, int index2), string>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 == str1.Length)
            {
                return str2[index2..];
            }

            if (index2 == str2.Length)
            {
                return str1[index1..];
            }

            var ans1 = recursiveFunc((index1 + 1, index2));
            var ans2 = recursiveFunc((index1, index2 + 1));

            if (str1[index1] == ans1[0])
            {
                return ans1;
            }

            if (str2[index2] == ans2[0])
            {
                return ans2;
            }

            if (ans1.Length <= ans2.Length)
            {
                return str1[index1] + ans1;
            }

            return str2[index2] + ans2;
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
}
