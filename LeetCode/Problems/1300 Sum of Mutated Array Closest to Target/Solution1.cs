using JetBrains.Annotations;

namespace LeetCode.Problems._1300_Sum_of_Mutated_Array_Closest_to_Target;

/// <summary>
/// https://leetcode.com/submissions/detail/950602396/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int FindBestValue(int[] arr, int target)
    {
        Array.Sort(arr);

        var n = arr.Length;
        var prefixSums = new int[n];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i] = (i > 0 ? prefixSums[i - 1] : 0) + arr[i];
        }

        var low = 1;
        var high = 100_000;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var newSum = NewSum(mid);

            if (newSum >= target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        var diffHigh = Math.Abs(NewSum(high) - target);
        var diffLow = Math.Abs(NewSum(low) - target);

        return diffHigh <= diffLow ? high : low;

        int NewSum(int replacementValue)
        {
            var low2 = 0;
            var high2 = arr.Length - 1;

            while (low2 <= high2)
            {
                var mid2 = low2 + (high2 - low2 >> 1);

                if (arr[mid2] < replacementValue)
                {
                    low2 = mid2 + 1;
                }
                else
                {
                    high2 = mid2 - 1;
                }
            }

            return (low2 > 0 ? prefixSums[low2 - 1] : 0) + replacementValue * (n - low2);
        }
    }
}
