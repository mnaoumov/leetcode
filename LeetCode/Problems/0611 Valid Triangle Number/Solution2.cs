namespace LeetCode.Problems._0611_Valid_Triangle_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/930960210/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);

        var n = nums.Length;
        var result = 0;

        for (var i = 0; i < n - 2; i++)
        {
            if (nums[i] == 0)
            {
                continue;
            }

            for (var j = i + 1; j < n - 1; j++)
            {
                var low = j + 1;
                var high = n - 1;

                while (low <= high)
                {
                    var mid = low + (high - low >> 1);

                    if (nums[mid] >= nums[i] + nums[j])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                result += high - j;
            }
        }

        return result;
    }
}
