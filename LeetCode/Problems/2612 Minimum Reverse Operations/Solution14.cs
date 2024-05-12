using JetBrains.Annotations;

namespace LeetCode._2612_Minimum_Reverse_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/926714267/
/// </summary>
[UsedImplicitly]
public class Solution14 : ISolution
{
    public int[] MinReverseOperations(int n, int p, int[] banned, int k)
    {
        const int impossible = -1;
        var ans = Enumerable.Repeat(impossible, n).ToArray();
        var bannedSet = banned.ToHashSet();
        var indicesToCheck = new[] { new SortedSet<int>(), new SortedSet<int>() };

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

            indicesToCheck[i % 2].Add(i);
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

                indicesToCheck[i % 2].Remove(i);

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

                var set = indicesToCheck[low % 2];

                foreach (var j in set.GetViewBetween(low, high).Where(j => (i + j + k + 1) % 2 == 0).ToArray())
                {
                    if (ans[j] != impossible)
                    {
                        continue;
                    }

                    queue.Enqueue(j);
                    set.Remove(j);
                }
            }

            step++;
        }

        return ans;
    }
}
