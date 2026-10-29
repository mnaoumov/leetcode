namespace LeetCode.Problems._2071_Maximum_Number_of_Tasks_You_Can_Assign;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-tasks-you-can-assign/submissions/1622408640/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        Array.Sort(tasks);
        Array.Sort(workers);
        var n = tasks.Length;
        var m = workers.Length;

        var dp = new DynamicProgramming<(int taskIndex, int workerIndex, int pillsLeft), int>((key, recursiveFunc) =>
        {
            var (taskIndex, workerIndex, pillsLeft) = key;

            if (taskIndex < 0 || workerIndex < 0)
            {
                return 0;
            }

            var ans = 0;
            var index = BinarySearchLast(tasks, workers[workerIndex], 0, taskIndex);

            if (index >= 0)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((taskIndex - 1, index - 1, pillsLeft)));
            }

            if (pillsLeft == 0)
            {
                return ans;
            }

            index = BinarySearchLast(tasks, workers[workerIndex] + strength, 0, taskIndex);
            if (index >= 0)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((taskIndex - 1, index - 1, pillsLeft - 1)));
            }
            return ans;
        });

        return dp.GetOrCalculate((n - 1, m - 1, pills));
    }

    private static int BinarySearchLast<T>(IReadOnlyList<T> arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid].CompareTo(value) > 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return high;
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
