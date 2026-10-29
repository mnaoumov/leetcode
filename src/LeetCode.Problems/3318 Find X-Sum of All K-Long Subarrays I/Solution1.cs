namespace LeetCode.Problems._3318_Find_X_Sum_of_All_K_Long_Subarrays_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-419/submissions/detail/1420565831/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        var n = nums.Length;
        var counts = new Dictionary<int, int>();

        var pq = new PriorityQueue<(int count, int num), (int inverseCount, int inverseNum)>();

        var ans = new int[n - k + 1];

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
                int count;
                int num;

                do
                {
                    (count, num) = pq.Dequeue();
                } while (dequeuedNums.Contains(num) || counts[num] != count);

                dequeuedNums.Add(num);
                ans[i - k + 1] += num * count;
            }

            foreach (var num in dequeuedNums)
            {
                AddToPriorityQueue(num);
            }

            var oldNum = nums[i - k + 1];
            counts[oldNum]--;
            AddToPriorityQueue(oldNum);
        }

        return ans;

        void AddToPriorityQueue(int num) => pq.Enqueue((counts[num], num), (-counts[num], -num));
    }
}
