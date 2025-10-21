namespace LeetCode.Problems._3719_Longest_Balanced_Subarray_I;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int LongestBalanced(int[] nums)
    {
        var n = nums.Length;
        var prefixCounts = new Dictionary<int, int>[n + 1];
        prefixCounts[0] = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            prefixCounts[i + 1] = prefixCounts[i].ToDictionary();
            prefixCounts[i + 1].TryAdd(num, 0);
            prefixCounts[i + 1][num]++;
        }

        for (var length = n; length >= 1; length--)
        {
            for (var start = 0; start <= n - length; start++)
            {
                var end = start + length - 1;
                var evenCounts = 0;
                var oddCounts = 0;
                // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                foreach (var num in prefixCounts[end + 1].Keys)
                {
                    var count = prefixCounts[end + 1][num] - prefixCounts[start].GetValueOrDefault(num);

                    if (count <= 0)
                    {
                        continue;
                    }

                    if (num % 2 == 0)
                    {
                        evenCounts++;
                    }
                    else
                    {
                        oddCounts++;
                    }
                }

                if (evenCounts == oddCounts)
                {
                    return length;
                }
            }
        }

        return 0;
    }
}
