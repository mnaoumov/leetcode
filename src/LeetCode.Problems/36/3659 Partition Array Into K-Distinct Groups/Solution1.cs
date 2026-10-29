namespace LeetCode.Problems._3659_Partition_Array_Into_K_Distinct_Groups;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-464/problems/partition-array-into-k-distinct-groups/submissions/1746021711/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool PartitionArray(int[] nums, int k)
    {
        var n = nums.Length;

        if (n % k != 0)
        {
            return false;
        }

        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());

        var pq = new PriorityQueue<int, int>();
        foreach (var (num, count) in counts)
        {
            pq.Enqueue(num, -count);
        }

        for (var i = 0; i < n / k; i++)
        {
            var used = new List<int>();
            for (var j = 0; j < k; j++)
            {
                if (pq.Count == 0)
                {
                    return false;
                }
                var num = pq.Dequeue();
                used.Add(num);
                counts[num]--;
            }

            foreach (var num in used.Where(num => counts[num] > 0))
            {
                pq.Enqueue(num, -counts[num]);
            }
        }

        return true;
    }
}
