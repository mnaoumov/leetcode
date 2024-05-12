using JetBrains.Annotations;

namespace LeetCode._2597_The_Number_of_Beautiful_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/918940028/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int BeautifulSubsets(int[] nums, int k)
    {
        Array.Sort(nums);
        var result = 0;
        var counts = new Dictionary<int, int>();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i > nums.Length)
            {
                return;
            }

            if (counts.Count > 0)
            {
                result++;
            }

            for (var j = i; j < nums.Length; j++)
            {
                var num = nums[j];

                if (counts.GetValueOrDefault(num - k) > 0)
                {
                    continue;
                }

                counts[num] = counts.GetValueOrDefault(num) + 1;
                Backtrack(j + 1);
                counts[num]--;
            }
        }
    }
}
