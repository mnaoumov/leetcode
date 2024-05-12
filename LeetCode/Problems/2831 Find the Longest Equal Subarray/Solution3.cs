using JetBrains.Annotations;

namespace LeetCode.Problems._2831_Find_the_Longest_Equal_Subarray;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-359/submissions/detail/1026368354/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LongestEqualSubarray(IList<int> nums, int k)
    {
        var n = nums.Count;
        var nextIndices = Enumerable.Repeat(n, n).ToArray();
        var lastIndexMap = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (lastIndexMap.TryGetValue(num, out var lastIndex))
            {
                nextIndices[lastIndex] = i;
            }

            lastIndexMap[num] = i;
        }

        var indicesMap = Enumerable.Range(0, n).GroupBy(index => nums[index])
            .ToDictionary(g => g.Key, g => g.OrderBy(index => index).ToArray());

        var ans = 1;

        for (var i = 0; i < n; i++)
        {
            if (nextIndices[i] == n)
            {
                continue;
            }

            var num = nums[i];
            var indices = indicesMap[num];
            var indexOfIndex = Array.BinarySearch(indices, i);
            var low = indexOfIndex;
            var high = indices.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                var numsToRemove = indices[mid] - i - mid + indexOfIndex;

                if (numsToRemove <= k)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            ans = Math.Max(ans, low - indexOfIndex);
        }

        return ans;
    }
}
