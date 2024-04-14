using JetBrains.Annotations;

namespace LeetCode._3115_Maximum_Prime_Difference;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-393/submissions/detail/1231756639/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    private readonly Dictionary<int, bool> _primesCache = new()
    {
        [1] = false
    };

    public int MaximumPrimeDifference(int[] nums)
    {
        var n = nums.Length;

        var minIndex = Enumerable.Range(0, n).First(i => IsPrime(nums[i]));
        var maxIndex = Enumerable.Range(0, n).Select(i => n - 1 - i).First(i => IsPrime(nums[i]));

        return maxIndex - minIndex;
    }

    private bool IsPrime(int num)
    {
        if (_primesCache.TryGetValue(num, out var ans))
        {
            return ans;
        }

        for (var d = 2; d * d <= num; d++)
        {
            if (num % d == 0)
            {
                return _primesCache[num] = false;
            }
        }

        return _primesCache[num] = true;
    }
}
