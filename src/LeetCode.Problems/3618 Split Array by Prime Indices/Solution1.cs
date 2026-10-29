namespace LeetCode.Problems._3618_Split_Array_by_Prime_Indices;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-161/problems/split-array-by-prime-indices/submissions/1703602797/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long SplitArray(int[] nums)
    {
        var n = nums.Length;
        var sieve = new bool[n];
        Array.Fill(sieve, true);
        sieve[0] = false;
        sieve[1] = false;

        for (var i = 2; i < n; i++)
        {
            if (!sieve[i])
            {
                continue;
            }

            for (var j = i * 2; j < n; j += i)
            {
                sieve[j] = false;
            }
        }

        var sum = nums.Select(num => (long) num).Sum();
        var primesSum = nums.Where((_, index) => sieve[index]).Select(num => (long) num).Sum();
        return Math.Abs(sum - 2 * primesSum);
    }
}
