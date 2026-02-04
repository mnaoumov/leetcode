namespace LeetCode.Problems._3003_Maximize_the_Number_of_Partitions_After_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1139220623/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.StackOverflow)]
public class Solution3 : ISolution
{
    public int MaxPartitionsAfterOperations(string s, int k)
    {
        var n = s.Length;

        var dp = new DynamicProgramming<(int index, bool canChange, char changedFirstLetter, string usedPartitionLetters), int>((key, recursiveFunc) =>
        {
            var (index, canChange, changedFirstLetter, usedPartitionLetters) = key;

            if (index == n)
            {
                return usedPartitionLetters == "" ? 0 : 1;
            }

            var usedPartitionLettersSet = usedPartitionLetters.ToHashSet();

            var ans = 1;

            if (canChange)
            {
                for (var newLetter = 'a'; newLetter <= 'z'; newLetter++)
                {
                    if (usedPartitionLettersSet.Contains(newLetter) || newLetter == s[index])
                    {
                        continue;
                    }

                    ans = usedPartitionLettersSet.Count == k
                        ? Math.Max(ans, 1 + recursiveFunc((index, false, newLetter, "")))
                        : Math.Max(ans, recursiveFunc((index, false, newLetter, usedPartitionLetters)));
                }
            }

            usedPartitionLettersSet.Add(changedFirstLetter != 0 ? changedFirstLetter : s[index]);
            var nextUsedPartitionLetters = string.Concat(usedPartitionLettersSet.OrderBy(x => x));

            ans = usedPartitionLettersSet.Count == k + 1
                ? Math.Max(ans, 1 + recursiveFunc((index, canChange, '\0', "")))
                : Math.Max(ans, recursiveFunc((index + 1, canChange, '\0', nextUsedPartitionLetters)));

            return ans;
        });

        const int maxLettersCount = 26;
        return dp.GetOrCalculate((0, k < maxLettersCount, '\0', ""));
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
