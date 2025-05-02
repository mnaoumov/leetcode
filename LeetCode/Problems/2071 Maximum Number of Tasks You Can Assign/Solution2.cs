namespace LeetCode.Problems._2071_Maximum_Number_of_Tasks_You_Can_Assign;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-tasks-you-can-assign/submissions/1622420305/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        Array.Sort(tasks);
        Array.Sort(workers);
        var n = tasks.Length;
        var m = workers.Length;

        var dp = new DynamicProgramming<(string availableTaskIndicesStr, int workerIndex, int pillsLeft), int>((key, recursiveFunc) =>
        {
            var (availableTaskIndicesStr, workerIndex, pillsLeft) = key;

            var availableTaskIndices = availableTaskIndicesStr.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            if (availableTaskIndices.Count == 0 || workerIndex < 0)
            {
                return 0;
            }

            var ans = 0;
            Handle(workers[workerIndex], pillsLeft);

            if (pillsLeft > 0)
            {
                Handle(workers[workerIndex] + strength, pillsLeft - 1);
            }

            return ans;

            void Handle(int workerStrength, int newPillsLeft)
            {
                var low = 0;
                var high = availableTaskIndices.Count - 1;

                while (low <= high)
                {
                    var mid = low + (high - low >> 1);

                    if (tasks[availableTaskIndices[mid]] > workerStrength)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                if (high < 0)
                {
                    return;
                }

                var removedTaskIndex = availableTaskIndices[high];
                availableTaskIndices.RemoveAt(high);
                ans = Math.Max(ans,
                    1 + recursiveFunc((MakeIndicesStr(availableTaskIndices), workerIndex - 1, newPillsLeft)));
                availableTaskIndices.Insert(high, removedTaskIndex);
            }
        });

        return dp.GetOrCalculate((MakeIndicesStr(Enumerable.Range(0, n)), m - 1, pills));
    }

    private static string MakeIndicesStr(IEnumerable<int> indices) => string.Join(' ', indices);

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
