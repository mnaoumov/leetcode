using JetBrains.Annotations;

namespace LeetCode._2815_Max_Pair_Sum_in_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-358/submissions/detail/1019730293/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxSum(int[] nums)
    {
        var map = new Dictionary<int, PriorityQueue<int, int>>();

        foreach (var num in nums)
        {
            var maxDigit = MaxDigit(num);
            map.TryAdd(maxDigit, new PriorityQueue<int, int>());
            var pq = map[maxDigit];
            pq.Enqueue(num, -num);

            if (pq.Count > 2)
            {
                pq.Dequeue();
            }
        }

        return map.Values
            .Where(pq => pq.Count == 2)
            .Select(pq => pq.Dequeue() + pq.Dequeue())
            .Append(-1)
            .Max();
    }

    private static int MaxDigit(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            var digit = num % 10;
            num /= 10;
            ans = Math.Max(ans, digit);
        }

        return ans;
    }
}
