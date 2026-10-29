namespace LeetCode.Problems._3403_Find_the_Lexicographically_Largest_String_From_the_Box_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-430/submissions/detail/1491129834/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string AnswerString(string word, int numFriends)
    {
        var dp = new DynamicProgramming<(int startingIndex, int splitCount), string>((key, recursiveFunc) =>
        {
            var (startingIndex, splitCount) = key;

            if (splitCount == 1)
            {
                return word[startingIndex..];
            }

            var ans = "";

            for (var firstSplitLength = 1; firstSplitLength <= word.Length - startingIndex - splitCount + 1; firstSplitLength++)
            {
                var str = word[startingIndex..(startingIndex + firstSplitLength)];
                var next = recursiveFunc((startingIndex + firstSplitLength, splitCount - 1));

                if (string.CompareOrdinal(str, ans) > 0)
                {
                    ans = str;
                }

                if (string.CompareOrdinal(next, ans) > 0)
                {
                    ans = next;
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, numFriends));
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
