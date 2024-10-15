namespace LeetCode.Problems._0962_Maximum_Width_Ramp;

/// <summary>
/// https://leetcode.com/submissions/detail/1417531751/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxWidthRamp(int[] nums)
    {
        var minIndices = new List<int>();
        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var low = 0;
            var high = minIndices.Count - 1;
            var num = nums[i];

            while (low <= high)
            {
                var mid = low + (high - low >> 1);
                var currentNum = nums[minIndices[mid]];

                if (currentNum > num)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (low < minIndices.Count)
            {
                ans = Math.Max(ans, i - minIndices[low]);
            }

            if (minIndices.Count == 0 || num < nums[minIndices[^1]])
            {
                minIndices.Add(i);
            }
        }

        return ans;
    }
}
