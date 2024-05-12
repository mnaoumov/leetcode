using JetBrains.Annotations;

namespace LeetCode.Problems._2612_Minimum_Reverse_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/926434212/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution09 : ISolution
{
    public int[] MinReverseOperations(int n, int p, int[] banned, int k)
    {
        const int impossible = -1;
        var ans = Enumerable.Repeat(impossible, n).ToArray();
        var intervalsToProcess = new List<(int from, int to)> { (0, n) };

        foreach (var i in banned)
        {
            RemoveIndexToProcess(i);
        }

        var queue = new Queue<int>();
        queue.Enqueue(p);
        var step = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var _ = 0; _ < count; _++)
            {
                var i = queue.Dequeue();

                if (ans[i] != impossible)
                {
                    continue;
                }

                ans[i] = step;
                RemoveIndexToProcess(i);

                if (intervalsToProcess.Count == 0)
                {
                    break;
                }

                var low = Math.Abs(i - k + 1);
                var high = new[] { i + k - 1, 2 * n - k - 1 - i, n - 1 }.Min();

                if (low > high)
                {
                    continue;
                }

                var lowIntervalIndex = FindIntervalIndex(low);
                var highIntervalIndex = FindIntervalIndex(high);

                if (highIntervalIndex == intervalsToProcess.Count || intervalsToProcess[highIntervalIndex].from > high)
                {
                    highIntervalIndex--;
                }

                for (var intervalIndex = lowIntervalIndex; intervalIndex <= highIntervalIndex; intervalIndex++)
                {
                    for (var j = Math.Max(intervalsToProcess[intervalIndex].from, low); j < Math.Min(intervalsToProcess[intervalIndex].to, high + 1); j++)
                    {
                        if ((i + j + k + 1) % 2 != 0)
                        {
                            continue;
                        }

                        queue.Enqueue(j);
                    }
                }
            }

            step++;
        }

        return ans;

        void RemoveIndexToProcess(int value)
        {
            var intervalIndex = FindIntervalIndex(value);
            var (from, to) = intervalsToProcess[intervalIndex];
            intervalsToProcess.RemoveAt(intervalIndex);

            if (value + 1 < to)
            {
                intervalsToProcess.Insert(intervalIndex, (value + 1, to));
            }

            if (from < value)
            {
                intervalsToProcess.Insert(intervalIndex, (from, value));
            }
        }

        int FindIntervalIndex(int value)
        {
            var low = 0;
            var high = intervalsToProcess.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (value < intervalsToProcess[mid].from)
                {
                    high = mid - 1;
                }
                else if (intervalsToProcess[mid].to <= value)
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return low;
        }
    }
}
