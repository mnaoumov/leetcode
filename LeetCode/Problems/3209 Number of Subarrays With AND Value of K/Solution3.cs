using JetBrains.Annotations;

namespace LeetCode.Problems._3209_Number_of_Subarrays_With_AND_Value_of_K;

/// <summary>
/// https://leetcode.com/submissions/detail/1312211465/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public long CountSubarrays(int[] nums, int k)
    {
        const int bitsCount = 32;
        var n = nums.Length;
        var zeroBitsCountsPrefixes = new Dictionary<int, int[]>();
        var zeroBitsCounts = new int[bitsCount];
        zeroBitsCountsPrefixes[-1] = zeroBitsCounts.ToArray();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            for (var j = 0; j < bitsCount; j++)
            {
                if ((num & 1 << j) == 0)
                {
                    zeroBitsCounts[j]++;
                }
            }

            zeroBitsCountsPrefixes[i] = zeroBitsCounts.ToArray();
        }

        var kOneBits = new HashSet<int>();
        var kZeroBits = new HashSet<int>();

        for (var i = 0; i < bitsCount; i++)
        {
            if ((k & 1 << i) != 0)
            {
                kOneBits.Add(i);
            }
            else
            {
                kZeroBits.Add(i);
            }
        }

        if (kZeroBits.Any(j => zeroBitsCountsPrefixes[n - 1][j] == 0))
        {
            return 0;
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            if (kZeroBits.Any(j => zeroBitsCountsPrefixes[i][j] == 0))
            {
                continue;
            }

            var low = -1;
            var high = i - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (kOneBits.All(bit => zeroBitsCountsPrefixes[mid][bit] == zeroBitsCountsPrefixes[i][bit]))
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var minIndex = low;

            if (minIndex > i - 1)
            {
                continue;
            }

            if (kZeroBits.Any(bit => zeroBitsCountsPrefixes[minIndex][bit] == zeroBitsCountsPrefixes[i][bit]))
            {
                continue;
            }

            low = minIndex;
            high = i - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (kZeroBits.Any(bit => zeroBitsCountsPrefixes[mid][bit] == zeroBitsCountsPrefixes[i][bit]))
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var maxIndex = high;

            if (minIndex <= maxIndex)
            {
                ans += maxIndex - minIndex + 1;
            }
        }

        return ans;
    }
}
