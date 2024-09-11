using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2612_Minimum_Reverse_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/926407272/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution05 : ISolution
{
    public int[] MinReverseOperations(int n, int p, int[] banned, int k)
    {
        const int impossible = -1;
        var ans = Enumerable.Repeat(impossible, n).ToArray();
        var bannedSet = banned.ToHashSet();
        var indicesToCheck = new List<int>();

        for (var i = 0; i < n; i++)
        {
            if (bannedSet.Contains(i))
            {
                continue;
            }

            if (i == p)
            {
                continue;
            }

            indicesToCheck.Add(i);
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
                indicesToCheck.Remove(i);

                var low = Math.Abs(i - k + 1);
                var high = new[] { i + k - 1, 2 * n - k - 1 - i, n - 1 }.Min();

                if (low > high)
                {
                    continue;
                }

                var lowIndex = indicesToCheck.BinarySearch(low);

                if (lowIndex < 0)
                {
                    lowIndex = ~lowIndex;
                }

                var highIndex = indicesToCheck.BinarySearch(high);

                if (highIndex < 0)
                {
                    highIndex = ~highIndex - 1;
                }

                for (var index = lowIndex; index <= highIndex; index++)
                {
                    var j = indicesToCheck[index];

                    if ((i + j + k + 1) % 2 != 0)
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
