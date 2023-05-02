using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._2444_Count_Subarrays_With_Fixed_Bounds;

/// <summary>
/// https://leetcode.com/submissions/detail/823464695/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        if (minK > maxK)
        {
            return 0;
        }

        var dp = new Entry?[nums.Length + 1];

        return Get(0).Result;

        Entry Get(int startIndex)
        {
            if (dp[startIndex] is not { } result)
            {
                dp[startIndex] = result = Calculate();
            }

            return result;

            Entry Calculate()
            {
                if (startIndex >= nums.Length)
                {
                    return new Entry
                    {
                        IsInRange = false
                    };
                }

                var value = nums[startIndex];
                var isInRange = minK <= value && value <= maxK;
                var isMin = value == minK;
                var isMax = value == maxK;
                var subarraysWithMinMaxCount = isMin && isMax ? 1 : 0;
                var subarraysWithOnlyMaxCount = isMax && !isMin ? 1 : 0;
                var subarraysWithOnlyMinCount = isMin && !isMax ? 1 : 0;
                var subarraysWithoutMinMaxCount = isInRange && !isMin && !isMax ? 1 : 0;

                var nextEntry = Get(startIndex + 1);

                if (!nextEntry.IsInRange)
                {
                    return new Entry
                    {
                        SubarraysWithMinMaxCount = subarraysWithMinMaxCount,
                        SubarraysWithOnlyMaxCount = subarraysWithOnlyMaxCount,
                        SubarraysWithOnlyMinCount = subarraysWithOnlyMinCount,
                        SubarraysWithoutMinMaxCount = subarraysWithoutMinMaxCount,
                        IsInRange = true,
                        Result = subarraysWithMinMaxCount + nextEntry.Result
                    };
                }

                if (!isInRange)
                {
                    return new Entry
                    {
                        SubarraysWithMinMaxCount = 0,
                        SubarraysWithOnlyMaxCount = 0,
                        SubarraysWithOnlyMinCount = 0,
                        SubarraysWithoutMinMaxCount = 0,
                        IsInRange = false,
                        Result = nextEntry.Result
                    };
                }

                if (isMin && isMax)
                {
                    var newResult = nextEntry.SubarraysWithMinMaxCount + nextEntry.SubarraysWithoutMinMaxCount + 1;
                    return new Entry
                    {
                        SubarraysWithMinMaxCount = newResult,
                        SubarraysWithOnlyMaxCount = 0,
                        SubarraysWithOnlyMinCount = 0,
                        SubarraysWithoutMinMaxCount = 0,
                        IsInRange = true,
                        Result = nextEntry.Result + newResult
                    };
                }

                if (isMax)
                {
                    var newResult = nextEntry.SubarraysWithMinMaxCount + nextEntry.SubarraysWithOnlyMinCount;
                    return new Entry
                    {
                        SubarraysWithMinMaxCount = newResult,
                        SubarraysWithOnlyMaxCount = nextEntry.SubarraysWithOnlyMaxCount + nextEntry.SubarraysWithoutMinMaxCount + 1,
                        SubarraysWithOnlyMinCount = 0,
                        SubarraysWithoutMinMaxCount = 0,
                        IsInRange = true,
                        Result = nextEntry.Result + newResult
                    };
                }

                if (isMin)
                {
                    var newResult = nextEntry.SubarraysWithMinMaxCount + nextEntry.SubarraysWithOnlyMaxCount;
                    return new Entry
                    {
                        SubarraysWithMinMaxCount = newResult,
                        SubarraysWithOnlyMaxCount = 0,
                        SubarraysWithOnlyMinCount = nextEntry.SubarraysWithOnlyMinCount + nextEntry.SubarraysWithoutMinMaxCount + 1,
                        SubarraysWithoutMinMaxCount = 0,
                        IsInRange = true,
                        Result = nextEntry.Result + newResult
                    };
                }
                else
                {
                    var newResult = nextEntry.SubarraysWithMinMaxCount;
                    return new Entry
                    {
                        SubarraysWithMinMaxCount = newResult,
                        SubarraysWithOnlyMaxCount = nextEntry.SubarraysWithOnlyMaxCount,
                        SubarraysWithOnlyMinCount = nextEntry.SubarraysWithOnlyMinCount,
                        SubarraysWithoutMinMaxCount = nextEntry.SubarraysWithoutMinMaxCount,
                        IsInRange = true,
                        Result = nextEntry.Result + newResult
                    };
                }
            }
        }
    }

    class Entry
    {
        public long SubarraysWithMinMaxCount { get; set; }
        public long SubarraysWithOnlyMinCount { get; set; }
        public long SubarraysWithOnlyMaxCount { get; set; }
        public long SubarraysWithoutMinMaxCount { get; set; }
        public long Result { get; set; }
        public bool IsInRange { get; set; }
    }
}
