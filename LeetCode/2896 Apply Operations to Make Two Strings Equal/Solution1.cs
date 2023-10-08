using System.Text;
using JetBrains.Annotations;

namespace LeetCode._2896_Apply_Operations_to_Make_Two_Strings_Equal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-366/submissions/detail/1069788768/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinOperations(string s1, string s2, int x)
    {
        var dp = new DynamicProgramming<(string str1, string str2), int>((key, recursiveFunc) =>
        {
            var (str1, str2) = key;

            if (str1 == str2)
            {
                return 0;
            }

            var sb1 = new StringBuilder(str1);
            var sb2 = new StringBuilder(str2);
            sb1.Remove(0, 1);
            sb2.Remove(0, 1);

            if (str1[0] == str2[0])
            {
                return recursiveFunc((sb1.ToString(), sb2.ToString()));
            }

            var n = sb1.Length;

            if (n == 0)
            {
                return -1;
            }

            var ans = int.MaxValue;

            Invert(sb1, 0);
            var ans2 = recursiveFunc((sb1.ToString(), sb2.ToString()));
            Invert(sb1, 0);

            if (ans2 != -1)
            {
                ans = Math.Min(ans, 1 + ans2);
            }

            for (var i = 0; i < n; i++)
            {
                Invert(sb2, i);
                ans2 = recursiveFunc((sb1.ToString(), sb2.ToString()));
                Invert(sb2, i);

                if (ans2 != -1)
                {
                    ans = Math.Min(ans, x + ans2);
                }

                Invert(sb1, i);
                ans2 = recursiveFunc((sb1.ToString(), sb2.ToString()));
                Invert(sb1, i);

                if (ans2 != -1)
                {
                    ans = Math.Min(ans, x + ans2);
                }
            }

            return ans == int.MaxValue ? -1 : ans;
        });

        return dp.GetOrCalculate((s1, s2));

        void Invert(StringBuilder sb, int index) => sb[index] = sb[index] == '0' ? '1' : '0';
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
