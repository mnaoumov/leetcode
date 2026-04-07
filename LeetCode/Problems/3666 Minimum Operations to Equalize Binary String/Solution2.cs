namespace LeetCode.Problems._3666_Minimum_Operations_to_Equalize_Binary_String;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-equalize-binary-string/submissions/1932326835/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinOperations(string s, int k)
    {
        var n = s.Length;
        var zeroCount = s.Count(digit => digit == '0');

        if (k % 2 == 0 && zeroCount % 2 == 1)
        {
            return -1;
        }

        const int unknown = -1;
        var distances = Enumerable.Repeat(unknown, n + 1).ToArray();
        var queue = new Queue<int>();
        queue.Enqueue(zeroCount);
        distances[zeroCount] = 0;

        var unprocessed = new[] { new SortedSet<int>(), new SortedSet<int>() };

        for (var i = 0; i < n; i++)
        {
            var parity = i & 1;
            unprocessed[parity].Add(i);
        }

        unprocessed[zeroCount & 1].Remove(zeroCount);

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                zeroCount = queue.Dequeue();

                if (zeroCount == 0)
                {
                    return distances[0];
                }

                var parity = (zeroCount + k) & 1;
                var a = Math.Max(0, k - n + zeroCount);
                var b = Math.Min(zeroCount, k);
                var c = zeroCount + k - 2 * b;
                var d = zeroCount + k - 2 * a;

                foreach (var next in unprocessed[parity].GetViewBetween(c, d).ToArray())
                {
                    distances[next] = distances[zeroCount] + 1;
                    queue.Enqueue(next);
                    unprocessed[parity].Remove(next);
                }
            }
        }

        return unknown;
    }
}
