namespace LeetCode.Problems._3896_Minimum_Operations_to_Transform_Array_into_Alternating_Prime;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-180/problems/minimum-operations-to-transform-array-into-alternating-prime/submissions/1975560728/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var max = nums.Max();
        var primes = new SortedSet<int>();
        int n;

        for (n = 2; n <= max; n++)
        {
            if (IsPrime(n))
            {
                primes.Add(n);
            }
        }

        n = max;

        while (!IsPrime(n) || n == 1)
        {
            n++;
        }

        primes.Add(n);

        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (i % 2 == 0)
            {
                var nextPrime = primes.GetViewBetween(num, int.MaxValue).Min;
                ans += nextPrime - num;
            }
            else if (primes.Contains(num))
            {
                if (num == 2)
                {
                    ans += 2;
                }
                else
                {
                    ans++;
                }
            }
        }

        return ans;

        bool IsPrime(int num)
        {
            var maxP = (int) Math.Sqrt(num);
            return primes.TakeWhile(p => p <= maxP).All(p => n % p != 0);
        }
    }
}
