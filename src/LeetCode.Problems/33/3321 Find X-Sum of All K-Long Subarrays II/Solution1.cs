namespace LeetCode.Problems._3321_Find_X_Sum_of_All_K_Long_Subarrays_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-419/submissions/detail/1420572271/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long[] FindXSum(int[] nums, int k, int x)
    {
        var n = nums.Length;
        var counts = new Dictionary<int, int>();

        var pq = new PriorityQueue<(int count, int num), (int inverseCount, int inverseNum)>();

        var ans = new long[n - k + 1];

        for (var i = 0; i < n; i++)
        {
            var newNum = nums[i];
            counts.TryAdd(newNum, 0);
            counts[newNum]++;
            AddToPriorityQueue(newNum);

            if (i < k - 1)
            {
                continue;
            }

            var dequeuedNums = new HashSet<int>();

            for (var j = 0; j < x; j++)
            {
                var count = 0;
                var num = 0;
                var isEmpty = false;

                do
                {
                    if (pq.Count == 0)
                    {
                        isEmpty = true;
                        break;
                    }
                    (count, num) = pq.Dequeue();
                } while (dequeuedNums.Contains(num) || counts.GetValueOrDefault(num) != count);

                if (isEmpty)
                {
                    break;
                }

                dequeuedNums.Add(num);
                ans[i - k + 1] += 1L * num * count;
            }

            foreach (var num in dequeuedNums)
            {
                AddToPriorityQueue(num);
            }

            var oldNum = nums[i - k + 1];
            counts[oldNum]--;

            if (counts[oldNum] == 0)
            {
                counts.Remove(oldNum);
            }
            else
            {
                AddToPriorityQueue(oldNum);
            }
        }

        return ans;

        void AddToPriorityQueue(int num) => pq.Enqueue((counts[num], num), (-counts[num], -num));
    }
}
