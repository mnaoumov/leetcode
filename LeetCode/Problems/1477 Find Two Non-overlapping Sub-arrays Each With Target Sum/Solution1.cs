namespace LeetCode.Problems._1477_Find_Two_Non_overlapping_Sub_arrays_Each_With_Target_Sum;

/// <summary>
/// https://leetcode.com/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum/submissions/2144297707/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinSumOfLengths(int[] arr, int target)
    {
        var n = arr.Length;

        var prefixSumIndexMap = new Dictionary<int, int> { [0] = -1 };

        const int notFound = -1;
        var prefixSumLengths = new int[n];
        Array.Fill(prefixSumLengths, notFound);

        var prefixSum = 0;

        for (var i = 0; i < n; i++)
        {
            prefixSum += arr[i];
            prefixSumIndexMap[prefixSum] = i;

            if (prefixSumIndexMap.TryGetValue(prefixSum - target, out var previousIndex))
            {
                prefixSumLengths[i] = i - previousIndex;
            }
            else if (i > 0)
            {
                prefixSumLengths[i] = prefixSumLengths[i - 1];
            }
        }

        var suffixSumIndexMap = new Dictionary<int, int> { [0] = n };
        var suffixSumLengths = new int[n];
        Array.Fill(suffixSumLengths, notFound);

        var suffixSum = 0;

        for (var i = n - 1; i >= 0; i--)
        {
            suffixSum += arr[i];
            suffixSumIndexMap[suffixSum] = i;

            if (suffixSumIndexMap.TryGetValue(suffixSum - target, out var nextIndex))
            {
                suffixSumLengths[i] = nextIndex - i;
            }
            else if (i < n - 1)
            {
                suffixSumLengths[i] = suffixSumLengths[i + 1];
            }
        }

        var ans = int.MaxValue;

        for (var i = 0; i < n - 1; i++)
        {
            if (prefixSumLengths[i] != notFound && suffixSumLengths[i + 1] != notFound)
            {
                ans = Math.Min(ans, prefixSumLengths[i] + suffixSumLengths[i + 1]);
            }
        }

        if (ans == int.MaxValue)
        {
            ans = notFound;
        }

        return ans;
    }
}
