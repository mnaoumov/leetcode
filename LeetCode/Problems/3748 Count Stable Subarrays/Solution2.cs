namespace LeetCode.Problems._3748_Count_Stable_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-476/problems/count-stable-subarrays/submissions/1830953489/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public long[] CountStableSubarrays(int[] nums, int[][] queries)
    {
        var stableIntervalLengths = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (i > 0 && num >= nums[i - 1])
            {
                stableIntervalLengths[^1]++;
            }
            else
            {
                stableIntervalLengths.Add(1);
            }
        }

        var stableSubintervalsCounts = stableIntervalLengths.Select(CountStableArrays).ToArray();
        var prefixStableSubintervalsCounts = new long[stableSubintervalsCounts.Length + 1];

        for (var i = 0; i < stableSubintervalsCounts.Length; i++)
        {
            prefixStableSubintervalsCounts[i + 1] = prefixStableSubintervalsCounts[i] + stableSubintervalsCounts[i];
        }

        var stableIntervalStartIndices = new List<int> { 0 };

        foreach (var length in stableIntervalLengths)
        {
            stableIntervalStartIndices.Add(stableIntervalStartIndices[^1] + length);
        }

        return queries.Select(query => Answer(query[0], query[1])).ToArray();

        long Answer(int l, int r)
        {
            var startIntervalIndexOfIndex = stableIntervalStartIndices.BinarySearch(l);

            if (startIntervalIndexOfIndex < 0)
            {
                startIntervalIndexOfIndex = ~startIntervalIndexOfIndex;
            }
            else
            {
                startIntervalIndexOfIndex++;
            }

            var endIntervalIndexOfIndex = stableIntervalStartIndices.BinarySearch(r);

            if (endIntervalIndexOfIndex < 0)
            {
                endIntervalIndexOfIndex = ~endIntervalIndexOfIndex - 1;
            }
            else
            {
                endIntervalIndexOfIndex--;
            }

            if (startIntervalIndexOfIndex <= endIntervalIndexOfIndex)
            {
                return (prefixStableSubintervalsCounts[endIntervalIndexOfIndex + 1] -
                        prefixStableSubintervalsCounts[startIntervalIndexOfIndex])
                       + CountStableArrays(stableIntervalStartIndices[startIntervalIndexOfIndex] - l)
                       + CountStableArrays(r - stableIntervalStartIndices[endIntervalIndexOfIndex + 1] + 1);
            }

            if (startIntervalIndexOfIndex == endIntervalIndexOfIndex + 1 && stableIntervalLengths.Count > 1)
            {
                return CountStableArrays(stableIntervalStartIndices[startIntervalIndexOfIndex] - l)
                    + CountStableArrays(r - stableIntervalStartIndices[endIntervalIndexOfIndex + 1] + 1);
            }

            return CountStableArrays(r - l + 1);
        }

    }

    private static long CountStableArrays(int length) => 1L * length * (length + 1) / 2;
}
