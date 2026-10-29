namespace LeetCode.Problems._3618_Split_Array_by_Prime_Indices;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-161/problems/split-array-by-prime-indices/submissions/1703610000/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long SplitArray(int[] nums)
    {
        var sum = nums.Select(num => (long) num).Sum();
        var n = nums.Length;

        if (n < 2)
        {
            return sum;
        }

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

        var primesSum = nums.Where((_, index) => sieve[index]).Select(num => (long) num).Sum();
        return Math.Abs(sum - 2 * primesSum);
    }
}
