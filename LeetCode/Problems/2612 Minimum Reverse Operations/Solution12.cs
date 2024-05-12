using JetBrains.Annotations;

namespace LeetCode.Problems._2612_Minimum_Reverse_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/926698892/
/// </summary>
[UsedImplicitly]
public class Solution12 : ISolution
{
    public int[] MinReverseOperations(int n, int p, int[] banned, int k)
    {
        var even = new SortedSet<int>();
        var odd = new SortedSet<int>();

        var skip = new bool[n];

        foreach (var num in banned)
        {
            skip[num] = true;
        }

        for (var i = 0; i < n; ++i)
        {
            if (skip[i] || i == p)
            {
                continue;
            }

            if (i % 2 == 1)
            {
                odd.Add(i);
            }
            else
            {
                even.Add(i);
            }
        }

        var result = new int[n];
        Array.Fill(result, -1);

        var queue = new Queue<int>();
        queue.Enqueue(p);

        var moves = 0;

        while (queue.Count > 0)
        {
            var size = queue.Count;

            while (size-- > 0)
            {
                var current = queue.Dequeue();

                result[current] = moves;

                int min;

                if (current < k - 1)
                {
                    min = k - 1 - current;
                }
                else
                {
                    min = current - k + 1;
                }

                // calculate max index
                var mCurrent = n - 1 - current;
                int max;

                if (mCurrent < k - 1)
                {
                    max = k - 1 - mCurrent;
                }
                else
                {
                    max = mCurrent - k + 1;
                }

                max = n - 1 - max;


                // chose the correct parity set
                var set = min % 2 == 0 ? even : odd;

                var key = set.GetViewBetween(min, int.MaxValue).Min;

                // add all values in range to the queue and remove from set
                while (min <= key && key <= max && set.Contains(key))
                {
                    queue.Enqueue(key);
                    set.Remove(key);
                    key = set.GetViewBetween(min, int.MaxValue).Min;
                }
            }

            ++moves;
        }


        return result;
    }
}
