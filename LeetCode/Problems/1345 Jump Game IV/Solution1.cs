using JetBrains.Annotations;

namespace LeetCode.Problems._1345_Jump_Game_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/909187049/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinJumps(int[] arr)
    {
        var n = arr.Length;
        var numIndicesMap = Enumerable.Range(0, n).GroupBy(index => arr[index])
            .ToDictionary(g => g.Key, g => g.ToArray());
        var seen = new HashSet<int>();

        var step = 0;
        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (true)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var index = queue.Dequeue();

                if (index < 0 || index >= n)
                {
                    continue;
                }

                if (!seen.Add(index))
                {
                    continue;
                }

                if (index == n - 1)
                {
                    return step;
                }

                queue.Enqueue(index - 1);
                queue.Enqueue(index + 1);

                foreach (var indexWithTheSameValue in numIndicesMap[arr[index]])
                {
                    queue.Enqueue(indexWithTheSameValue);
                }
            }

            step++;
        }
    }
}
