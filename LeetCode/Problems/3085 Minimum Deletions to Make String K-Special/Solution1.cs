using JetBrains.Annotations;

namespace LeetCode.Problems._3085_Minimum_Deletions_to_Make_String_K_Special;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-389/submissions/detail/1205876638/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDeletions(string word, int k)
    {
        var counts = word.GroupBy(letter => letter).Select(g => g.Count()).OrderBy(x => x).ToArray();

        var ans = int.MaxValue;

        var n = counts.Length;
        var suffixSums = new int[n + 1];

        for (var i = n - 1; i >= 0; i--)
        {
            suffixSums[i] = suffixSums[i + 1] + counts[i];
        }

        var prefixSum = 0;

        for (var i = 0; i < n; i++)
        {
            var maxCount = counts[i] + k;

            var low = 0;
            var high = n - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (counts[mid] > maxCount)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            ans = Math.Min(ans, prefixSum + suffixSums[low] - (n - low) * maxCount);
            prefixSum += counts[i];
        }

        return ans;
    }
}
