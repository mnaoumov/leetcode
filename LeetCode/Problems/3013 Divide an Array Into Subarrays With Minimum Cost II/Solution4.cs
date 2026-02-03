namespace LeetCode.Problems._3013_Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II;

/// <summary>
/// https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-ii/submissions/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public long MinimumCost(int[] nums, int k, int dist)
    {
        var list = new List<(int num, int index)>();

        for (var i = 2; i <= 1 + dist; i++)
        {
            var key = (nums[i], i);
            var index = ~list.BinarySearch(key);
            list.Insert(index, key);
        }

        var minSum = 0L;

        for (var j = 0; j < k - 2; j++)
        {
            minSum += list[j].num;
        }

        var ans = nums[0] + nums[1] + minSum;

        for (var i1 = 2; i1 < nums.Length + 2 - k; i1++)
        {
            var oldKey = (num: nums[i1], index: i1);
            var index = list.BinarySearch(oldKey);

            list.RemoveAt(index);

            if (index < k - 2)
            {
                minSum -= oldKey.num;

                if (list.Count > k - 3)
                {
                    minSum += list[k - 3].num;
                }
            }

            if (i1 + dist < nums.Length)
            {
                var newKey = (num: nums[i1 + dist], index: i1 + dist);
                index = ~list.BinarySearch(newKey);
                list.Insert(index, newKey);
                if (index < k - 2)
                {
                    minSum += newKey.num;

                    if (list.Count > k - 2)
                    {
                        minSum -= list[k - 2].num;
                    }
                }
            }

            ans = Math.Min(ans, nums[0] + nums[i1] + minSum);
        }

        return ans;
    }
}
