using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._100412_Final_Array_State_After_K_Multiplication_Operations_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-412/submissions/detail/1367341498/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    private const int Modulus = 1_000_000_007;

    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        var pq = new PriorityQueue<(BigInteger num, int index), (BigInteger num, int index)>();
        var n = nums.Length;

        if (n == 0)
        {
            throw new ArgumentException("n == 0");
        }

        for (var i = 0; i < n; i++)
        {
            var tuple = (nums[i], i);
            pq.Enqueue(tuple, tuple);
        }

        var ans = new int[n];

        if (1L * nums.Min() * multiplier > nums.Max())
        {
            var m = k / n;
            var r = k % n;

            var i = 0;

            while (pq.Count > 0)
            {
                var (num, index) = pq.Dequeue();

                var num2 = (int) (num * BigInteger.ModPow(multiplier, m + (i < r ? 1 : 0), Modulus) % Modulus);
                ans[index] = num2;
                i++;
            }

            return ans;
        }

        for (var i = 0; i < k; i++)
        {
            var (num, index) = pq.Dequeue();
            var tuple = (num * multiplier, index);
            pq.Enqueue(tuple, tuple);
        }

        while (pq.Count > 0)
        {
            var (num, index) = pq.Dequeue();
            ans[index] = (int) (num % 1_000_000_007);
        }

        return ans;

    }
}
