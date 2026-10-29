namespace LeetCode.Problems._3396_Minimum_Number_of_Operations_to_Make_Elements_in_Array_Distinct;

/// <summary>
/// https://leetcode.com/problems/minimum-number-of-operations-to-make-elements-in-array-distinct/submissions/1601125747/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperations(int[] nums)
    {
        var counts = nums.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var ans = 0;

        const int groupSize = 3;

        var n = nums.Length;
        while (counts.Count < n - groupSize * ans)
        {
            for (var i = 0; i < groupSize; i++)
            {
                var index = groupSize * ans + i;

                if (index >= n)
                {
                    break;
                }

                var num = nums[index];
                counts[num]--;
                if (counts[num] == 0)
                {
                    counts.Remove(num);
                }
            }
            ans++;
        }

        return ans;
    }
}
