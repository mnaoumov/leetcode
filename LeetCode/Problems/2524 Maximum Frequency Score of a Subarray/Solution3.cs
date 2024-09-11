namespace LeetCode.Problems._2524_Maximum_Frequency_Score_of_a_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/870797265/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    private const int Modulo = 1_000_000_007;

    private readonly DynamicProgramming<(int a, int b), int> _powerByModuloDp = new((key, recursiveFunc) =>
    {
        var (a, b) = key;

        if (b == 0)
        {
            return 1;
        }

        return (int) ((long) a * recursiveFunc((a, b - 1)) % Modulo);
    });

    public int MaxFrequencyScore(int[] nums, int k)
    {
        var frequenciesMap = new Dictionary<int, int>();

        for (var i = 0; i < k; i++)
        {
            var num = nums[i];
            frequenciesMap[num] = frequenciesMap.GetValueOrDefault(num) + 1;
        }

        var score = AddByModulo(frequenciesMap.Select(kvp => PowerByModulo(kvp.Key, kvp.Value)));
        var maxScore = score;

        for (var i = k; i < nums.Length; i++)
        {
            var previousNum = nums[i - k];
            var num = nums[i];

            if (previousNum == num)
            {
                continue;
            }

            frequenciesMap[previousNum]--;

            if (frequenciesMap[previousNum] == 0)
            {
                frequenciesMap.Remove(previousNum);
            }

            frequenciesMap[num] = frequenciesMap.GetValueOrDefault(num) + 1;

            score = AddByModulo(new[]
            {
                score,
                -PowerByModulo(previousNum, frequenciesMap.GetValueOrDefault(previousNum) + 1),
                PowerByModulo(previousNum, frequenciesMap.GetValueOrDefault(previousNum)),
                PowerByModulo(num, frequenciesMap.GetValueOrDefault(num)),
                frequenciesMap[num] == 1 ? 0 : -PowerByModulo(num, frequenciesMap.GetValueOrDefault(num) - 1)
            });

            maxScore = Math.Max(maxScore, score);
        }

        return maxScore;
    }

    private static int AddByModulo(IEnumerable<int> enumerable) => enumerable.Aggregate((a, b) => ((a + b) % Modulo + Modulo) % Modulo);

    private int PowerByModulo(int a, int b) => _powerByModuloDp.GetOrCalculate((a, b));

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
