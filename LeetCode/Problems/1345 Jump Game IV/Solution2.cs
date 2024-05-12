using JetBrains.Annotations;

namespace LeetCode._1345_Jump_Game_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/909192013/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinJumps(int[] arr)
    {
        var n = arr.Length;
        var numIndicesMap = Enumerable.Range(0, n).GroupBy(index => arr[index])
            .ToDictionary(g => g.Key, g => g.ToList());
        var seen = new bool[n];

        var step = 0;
        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (true)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var index = queue.Dequeue();
                seen[index] = true;

                if (index == n - 1)
                {
                    return step;
                }

                if (index > 0 && !seen[index - 1])
                {
                    queue.Enqueue(index - 1);
                }

                if (index < n - 1 && !seen[index + 1])
                {
                    queue.Enqueue(index + 1);
                }

                foreach (var indexWithTheSameValue in numIndicesMap[arr[index]])
                {
                    queue.Enqueue(indexWithTheSameValue);
                }

                numIndicesMap[arr[index]].Clear();
            }

            step++;
        }
    }
}
