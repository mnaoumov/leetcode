using JetBrains.Annotations;

namespace LeetCode.Problems._2653_Sliding_Subarray_Beauty;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-342/submissions/detail/938212922/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] GetSubarrayBeauty(int[] nums, int k, int x)
    {
        var n = nums.Length;
        var ans = new int[n - k + 1];
        var list = new List<int>();

        for (var i = 0; i < k - 1; i++)
        {
            var num = nums[i];

            if (num >= 0)
            {
                continue;
            }

            var index = list.BinarySearch(num);

            if (index < 0)
            {
                index = ~index;
            }

            list.Insert(index, num);
        }

        for (var i = 0; i < ans.Length; i++)
        {
            var lastNum = nums[i + k - 1];

            int index;

            if (lastNum < 0)
            {
                index = list.BinarySearch(lastNum);

                if (index < 0)
                {
                    index = ~index;
                }

                list.Insert(index, lastNum);
            }

            if (list.Count >= x)
            {
                ans[i] = list[x - 1];
            }

            var firstNum = nums[i];

            if (firstNum >= 0)
            {
                continue;
            }

            index = list.BinarySearch(firstNum);

            if (index >= 0)
            {
                list.RemoveAt(index);
            }
        }

        return ans;
    }
}
