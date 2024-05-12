using JetBrains.Annotations;

namespace LeetCode.Problems._3038_Maximum_Number_of_Operations_With_the_Same_Score_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-124/submissions/detail/1177862735/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxOperations(int[] nums)
    {
        var sum = nums[0] + nums[1];
        var ans = 1;

        for (var i = 3; i < nums.Length; i += 2)
        {
            if (nums[i] + nums[i - 1] != sum)
            {
                break;
            }

            ans++;
        }

        return ans;
    }
}
