namespace LeetCode.Problems._3209_Number_of_Subarrays_With_AND_Value_of_K;

/// <summary>
/// https://leetcode.com/submissions/detail/1311947926/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long CountSubarrays(int[] nums, int k)
    {
        const int bitsCount = 32;
        var n = nums.Length;
        var zeroBitsCountsPrefixes = new int[n][];

        var zeroBitsCounts = new int[bitsCount];

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

        for (var i = 0; i < bitsCount; i++)
        {
            if ((k & 1 << i) != 0)
            {
                kOneBits.Add(i);
            }
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            var isValid = true;

            for (var j = 0; j < bitsCount; j++)
            {
                if (kOneBits.Contains(j))
                {
                    continue;
                }

                if (zeroBitsCountsPrefixes[i][j] != 0)
                {
                    continue;
                }

                isValid = false;
                break;
            }

            if (!isValid)
            {
                continue;
            }

            var min = -1;
            var max = i - 1;

            while (min <= max)
            {
                var mid = min + (max - min >> 1);

                if (IsValid(mid))
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            var min2 = min;
            max = i - 1;

            while (min <= max)
            {
                var mid = min + (max - min >> 1);

                if (IsValid(mid))
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            var max2 = min;

            if (min2 <= max2)
            {
                ans += 0L + max2 - min2;
            }

            continue;

            bool IsValid(int mid)
            {
                zeroBitsCounts = mid >= 0 ? zeroBitsCountsPrefixes[mid] : new int[bitsCount];

                for (var j = 0; j < bitsCount; j++)
                {
                    if (kOneBits.Contains(j))
                    {
                        if (zeroBitsCounts[j] < zeroBitsCountsPrefixes[i][j])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (zeroBitsCounts[j] == zeroBitsCountsPrefixes[i][j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        return ans;
    }
}
