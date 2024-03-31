using JetBrains.Annotations;

namespace LeetCode._3092_Most_Frequent_IDs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-390/submissions/detail/1212167477/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long[] MostFrequentIDs(int[] nums, int[] freq)
    {
        var n = nums.Length;
        var ans = new long[n];
        var counts = new Dictionary<int, long>();
        var pq = new PriorityQueue<(int num, long count), long>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            counts.TryAdd(num, 0);
            counts[num] += freq[i];
            pq.Enqueue((num, counts[num]), -counts[num]);

            while (true)
            {
                var (mostFrequentNum, mostFrequentNumCount) = pq.Peek();

                if (counts[mostFrequentNum] != mostFrequentNumCount)
                {
                    pq.Dequeue();
                    continue;
                }

                ans[i] = mostFrequentNumCount;
                break;
            }
        }

        return ans;
    }
}
