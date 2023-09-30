using JetBrains.Annotations;

namespace LeetCode._2870_Minimum_Number_of_Operations_to_Make_Array_Empty;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-114/submissions/detail/1063112806/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var ans = 0;

        foreach (var count in nums.GroupBy(num => num).Select(g => g.Count()))
        {
            if (count == 1)
            {
                return -1;
            }

            ans += count / 3;

            if (count % 3 != 0)
            {
                ans++;
            }
        }

        return ans;
    }
}
