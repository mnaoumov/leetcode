using JetBrains.Annotations;

namespace LeetCode.Problems._0315_Count_of_Smaller_Numbers_After_Self;

/// <summary>
/// https://leetcode.com/submissions/detail/951654066/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> CountSmaller(int[] nums)
    {
        var n = nums.Length;
        var ans = new int[n];
        var sorted = new List<int>();

        for (var i = n - 1; i >= 0; i--)
        {
            var num = nums[i];

            var low = 0;
            var high = sorted.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (sorted[mid] < num)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            sorted.Insert(low, num);

            ans[i] = low;
        }

        return ans;
    }
}
