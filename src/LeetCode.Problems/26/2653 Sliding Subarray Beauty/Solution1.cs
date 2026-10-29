namespace LeetCode.Problems._2653_Sliding_Subarray_Beauty;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-342/submissions/detail/938199030/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] GetSubarrayBeauty(int[] nums, int k, int x)
    {
        var n = nums.Length;
        var ans = new int[n - k + 1];
        var pq = new PriorityQueue<int, int>();
        var counts = new Dictionary<int, int>();

        for (var i = 0; i < k - 1; i++)
        {
            var num = nums[i];

            if (num >= 0)
            {
                continue;
            }

            pq.Enqueue(num, -num);
            counts.TryAdd(num, 0);
            counts[num]++;

            if (pq.Count > x)
            {
                pq.Dequeue();
            }
        }

        var count = pq.Count;

        for (var i = 0; i < ans.Length; i++)
        {
            var lastNum = nums[i + k - 1];

            if (lastNum < 0)
            {
                pq.Enqueue(lastNum, -lastNum);
                counts.TryAdd(lastNum, 0);
                counts[lastNum]++;

                count++;

                if (count > x)
                {
                    var oldMin = pq.Dequeue();
                    count--;
                    counts[oldMin]--;
                }
            }

            if (count == x)
            {
                while (true)
                {
                    var min = pq.Peek();

                    if (counts[min] > 0)
                    {
                        ans[i] = pq.Peek();
                        break;
                    }

                    pq.Dequeue();
                }
            }

            var firstNum = nums[i];

            if (firstNum >= 0)
            {
                continue;
            }

            if (counts[firstNum] == 0)
            {
                continue;
            }

            counts[firstNum]--;
            count--;
        }

        return ans;
    }
}
