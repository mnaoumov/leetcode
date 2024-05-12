using JetBrains.Annotations;
using LeetCode.Problems._2612_Minimum_Reverse_Operations;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._6365_Minimum_Reverse_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/926693841/
/// Java https://leetcode.com/submissions/detail/926685616/
/// </summary>
[UsedImplicitly]
public class Solution11 : ISolution
{
    public int[] MinReverseOperations(int n, int p, int[] banned, int k)
    {
        var even = new SortedSet<int>();
        var odd = new SortedSet<int>();

        SortedSet<int> set;

        bool[] skip = new bool[n];

        foreach (int num in banned)
        {
            skip[num] = true;
        }

        int start = p;

        // Add values to the set that are not banned
        for (int i = 0; i < n; ++i)
        {
            if (skip[i] || i == p)
                continue;

            if (i % 2 == 1)
                odd.Add(i);
            else
                even.Add(i);
        }

        int[] result = new int[n];
        Array.Fill(result, -1);

        var queue = new Queue<int>();
        queue.Enqueue(p);

        int size;
        int current;
        int moves = 0;

        int min, max;

        int key;

        int mCurrent;

        while (queue.Count > 0)
        {
            size = queue.Count;


            while (size-- > 0)
            {
                current = queue.Dequeue();

                result[current] = moves;


                // calculate min index
                if (current < k - 1)
                {
                    min = (k - 1) - current;
                }
                else
                {
                    min = current - k + 1;
                }

                // calculate max index
                mCurrent = (n - 1) - current;
                if (mCurrent < k - 1)
                {
                    max = (k - 1) - mCurrent;
                }
                else
                {
                    max = mCurrent - k + 1;
                }
                max = (n - 1) - max;


                // chose the correct parity set
                set = min % 2 == 0 ? even : odd;

                key = set.GetViewBetween(min, int.MaxValue).Min;

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
