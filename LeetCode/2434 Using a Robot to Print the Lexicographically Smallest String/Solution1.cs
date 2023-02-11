using JetBrains.Annotations;

namespace LeetCode._2434_Using_a_Robot_to_Print_the_Lexicographically_Smallest_String;

/// <summary>
/// https://leetcode.com/submissions/detail/890331278/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string RobotWithString(string s)
    {
        var dp = new DynamicProgramming<(int index, string t), string>((key, recursiveFunc) =>
        {
            var (index, t) = key;

            var result = "";

            if (index < s.Length)
            {
                result = recursiveFunc((index + 1, t + s[index]));
            }

            if (t == "")
            {
                return result;
            }

            var takeFromTResult = t[^1] + recursiveFunc((index, t.Remove(t.Length - 1)));

            if (result == "" || string.Compare(takeFromTResult, result, StringComparison.Ordinal) < 0)
            {
                result = takeFromTResult;
            }

            return result;
        });

        return dp.GetOrCalculate((0, ""));
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
