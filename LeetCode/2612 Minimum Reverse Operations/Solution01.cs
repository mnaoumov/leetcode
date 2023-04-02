using JetBrains.Annotations;

namespace LeetCode._2612_Minimum_Reverse_Operations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-339/submissions/detail/926331453/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution01 : ISolution
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

            for (var i = 0; i < count; i++)
            {
                var index = queue.Dequeue();
                ans[index] = step;

                for (var a = Math.Max(0, i - k + 1); a < Math.Min(i + 1, n - k + 1); a++)
                {
                    var b = a + k - 1;
                    var j = a + b - i;

                    if (j == index)
                    {
                        continue;
                    }

                    if (bannedSet.Contains(j))
                    {
                        continue;
                    }

                    if (ans[j] != impossible)
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
