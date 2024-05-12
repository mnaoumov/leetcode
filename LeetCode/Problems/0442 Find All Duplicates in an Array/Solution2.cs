using JetBrains.Annotations;

namespace LeetCode._0442_Find_All_Duplicates_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1213917140/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> FindDuplicates(int[] nums)
    {
        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            while (true)
            {
                var num = nums[i];

                if (nums[num - 1] == num)
                {
                    break;
                }

                (nums[num - 1], nums[i]) = (num, nums[num - 1]);
            }
        }

        var ans = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (num != i + 1)
            {
                ans.Add(num);
            }
        }

        return ans;
    }
}
