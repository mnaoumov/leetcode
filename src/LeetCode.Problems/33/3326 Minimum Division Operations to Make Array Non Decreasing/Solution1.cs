namespace LeetCode.Problems._3326_Minimum_Division_Operations_to_Make_Array_Non_Decreasing;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-420/submissions/detail/1427904621/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    private readonly Dictionary<int, int> _minimumDivisorCache = new();
    private readonly List<int> _primes = new();

    public int MinOperations(int[] nums)
    {
        InitPrimes(nums.Max());
        _minimumDivisorCache[1] = 1;

        var n = nums.Length;
        var ans = 0;

        var firstIndex = 0;

        while (true)
        {
            var firstDecreasingIndex = GetFirstDecreasingIndex(nums, firstIndex);

            if (firstDecreasingIndex == n)
            {
                return ans;
            }

            for (var i = firstDecreasingIndex - 1; i >= firstIndex; i--)
            {
                var num = nums[i];
                var minimumDivisor = GetMinimumDivisor(num);

                if (minimumDivisor != num)
                {
                    ans++;
                    nums[i] = minimumDivisor;
                }

                if (nums[i] > nums[i + 1])
                {
                    return -1;
                }

                if (i > 0 && nums[i] >= nums[i - 1])
                {
                    break;
                }
            }

            firstIndex = firstDecreasingIndex;
        }
    }

    private void InitPrimes(int max)
    {
        for (var num = 2; num <= max; num++)
        {
            var isPrime = _primes.TakeWhile(p => p * p <= num).All(p => num % p != 0);

            if (!isPrime)
            {
                continue;
            }

            _primes.Add(num);
            _minimumDivisorCache[num] = num;
        }
    }

    private int GetMinimumDivisor(int num)
    {
        if (!_minimumDivisorCache.TryGetValue(num, out var divisor))
        {
            divisor = _minimumDivisorCache[num] = _primes.TakeWhile(p => p * p <= num).First(p => num % p == 0);
        }

        return divisor;
    }

    private static int GetFirstDecreasingIndex(int[] nums, int firstIndex)
    {
        var n = nums.Length;

        for (var i = firstIndex + 1; i < n; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                return i;
            }
        }

        return n;
    }
}
