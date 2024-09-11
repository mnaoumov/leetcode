using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2671_Frequency_Tracker;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-344/submissions/detail/945807727/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFrequencyTracker Create() => new FrequencyTracker();

    private class FrequencyTracker : IFrequencyTracker
    {
        private readonly Dictionary<int, int> _frequencyMap = new();
        private readonly Dictionary<int, int> _frequencyCounts = new();

        public void Add(int number)
        {
            var frequency = IncrementFrequency(_frequencyMap, number);
            IncrementFrequency(_frequencyCounts, frequency);
        }

        private static int IncrementFrequency<T>(IDictionary<T, int> dict, T key) where T : notnull
        {
            if (!dict.TryGetValue(key, out var frequency))
            {
                frequency = 0;
            }

            dict[key] = frequency + 1;
            return frequency + 1;
        }

        private static int DecrementFrequency<T>(IDictionary<T, int> dict, T key) where T : notnull
        {
            if (!dict.TryGetValue(key, out var frequency))
            {
                return -1;
            }

            if (frequency == 1)
            {
                dict.Remove(key);
            }
            else
            {
                dict[key] = frequency - 1;
            }

            return frequency - 1;
        }

        public void DeleteOne(int number)
        {
            var frequency = DecrementFrequency(_frequencyMap, number);

            switch (frequency)
            {
                case -1:
                    return;
                case > 0:
                    IncrementFrequency(_frequencyCounts, frequency);
                    break;
            }

            DecrementFrequency(_frequencyCounts, frequency + 1);
        }

        public bool HasFrequency(int frequency) => _frequencyCounts.ContainsKey(frequency);
    }
}
