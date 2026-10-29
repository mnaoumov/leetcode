namespace LeetCode.Problems._3326_Minimum_Division_Operations_to_Make_Array_Non_Decreasing;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-420/submissions/detail/1427934795/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution2 : ISolution
{
    private readonly Dictionary<int, int> _minimumDivisorCache = new();
    private readonly List<int> _primes = new();

    public int MinOperations(int[] nums)
    {
        _minimumDivisorCache[1] = 1;
        _primes.Add(2);

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
        var composites = new HashSet<int>();

        for (var p = _primes[^1] + 1; p <= max; p++)
        {
            if (composites.Contains(p))
            {
                continue;
            }

            _primes.Add(p);
            _minimumDivisorCache[p] = p;

            for (var multiple = p * p; multiple <= max; multiple += p)
            {
                composites.Add(multiple);
            }
        }
    }

    private int GetMinimumDivisor(int num)
    {
        if (_minimumDivisorCache.TryGetValue(num, out var divisor))
        {
            return divisor;
        }

        var minDivisor = _primes.TakeWhile(p => p * p <= num).FirstOrDefault(p => num % p == 0);
        var knownPrimesLength = _primes.Count;

        if (minDivisor != 0)
        {
            return _minimumDivisorCache[num] = minDivisor;
        }

        InitPrimes(num);
        if (_minimumDivisorCache.TryGetValue(num, out divisor))
        {
            return divisor;
        }

        minDivisor = _primes.Skip(knownPrimesLength).TakeWhile(p => p * p <= num).FirstOrDefault(p => num % p == 0);
        return _minimumDivisorCache[num] = minDivisor;
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
