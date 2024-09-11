namespace LeetCode.Problems._3209_Number_of_Subarrays_With_AND_Value_of_K;

/// <summary>
/// https://leetcode.com/submissions/detail/1312211465/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
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

        var kZeroBits = new HashSet<int>();

        for (var i = 0; i < bitsCount; i++)
        {
            if ((k & 1 << i) == 0)
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
            var low = i;
            var high = n - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                var val = CalculateAnd(i, mid);

                if (val >= k)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var minIndex = low;
            if (minIndex < i || minIndex >= n)
            {
                continue;
            }

            low = minIndex;
            high = n - 1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                var val = CalculateAnd(i, mid);

                if (val > k)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var maxIndex = low;

            ans += maxIndex - minIndex;
        }

        return ans;

        int CalculateAnd(int i, int j)
        {
            var prevZeroCountPrefix= zeroBitsCountsPrefixes[i - 1];
            var lastZeroCountPrefix = zeroBitsCountsPrefixes[j];

            var ans2 = 0;
            for (var l = 0; l < bitsCount; l++)
            {
                if (prevZeroCountPrefix[l] == lastZeroCountPrefix[l])
                {
                    ans2 += 1 << l;
                }
            }

            return ans2;
        }
    }
}
