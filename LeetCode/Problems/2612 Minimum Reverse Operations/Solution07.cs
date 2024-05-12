using JetBrains.Annotations;

namespace LeetCode.Problems._2612_Minimum_Reverse_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/926415598/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution07 : ISolution
{
    public int[] MinReverseOperations(int n, int p, int[] banned, int k)
    {
        const int impossible = -1;
        var ans = Enumerable.Repeat(impossible, n).ToArray();
        var bannedSet = banned.ToHashSet();

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

                var low = Math.Abs(i - k + 1);
                var high = new[] { i + k - 1, 2 * n - k - 1 - i, n - 1 }.Min();

                if (low > high)
                {
                    continue;
                }

                low += (i + low + k + 1) % 2;

                for (var j = low; j <= high; j += 2)
                {
                    if (ans[j] != impossible)
                    {
                        continue;
                    }

                    if (bannedSet.Contains(j))
                    {
                        continue;
                    }

                    queue.Enqueue(j);
                }
            }

            step++;
        }

        return ans;
    }
}
