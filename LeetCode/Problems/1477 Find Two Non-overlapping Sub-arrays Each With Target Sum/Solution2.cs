namespace LeetCode.Problems._1477_Find_Two_Non_overlapping_Sub_arrays_Each_With_Target_Sum;

/// <summary>
/// https://leetcode.com/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum/submissions/2144315325/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinSumOfLengths(int[] arr, int target)
    {
        var n = arr.Length;

        var prefixSumIndexMap = new Dictionary<int, int> { [0] = -1 };

        const int notFound = int.MaxValue;
        var prefixSumLengths = new int[n];
        Array.Fill(prefixSumLengths, notFound);

        var prefixSum = 0;

        for (var i = 0; i < n; i++)
        {
            prefixSum += arr[i];
            prefixSumIndexMap[prefixSum] = i;

            if (i > 0)
            {
                prefixSumLengths[i] = prefixSumLengths[i - 1];
            }

            if (prefixSumIndexMap.TryGetValue(prefixSum - target, out var previousIndex))
            {
                prefixSumLengths[i] = Math.Min(prefixSumLengths[i], i - previousIndex);
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

            if (i < n - 1)
            {
                suffixSumLengths[i] = suffixSumLengths[i + 1];
            }

            if (suffixSumIndexMap.TryGetValue(suffixSum - target, out var nextIndex))
            {
                suffixSumLengths[i] = Math.Min(suffixSumLengths[i], nextIndex - i);
            }
        }

        var ans = notFound;

        for (var i = 0; i < n - 1; i++)
        {
            if (prefixSumLengths[i] != notFound && suffixSumLengths[i + 1] != notFound)
            {
                ans = Math.Min(ans, prefixSumLengths[i] + suffixSumLengths[i + 1]);
            }
        }

        const int notFoundAns = -1;

        if (ans == notFound)
        {
            ans = notFoundAns;
        }

        return ans;
    }
}
