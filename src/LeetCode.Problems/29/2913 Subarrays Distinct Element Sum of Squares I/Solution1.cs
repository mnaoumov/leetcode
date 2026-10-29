namespace LeetCode.Problems._2913_Subarrays_Distinct_Element_Sum_of_Squares_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-116/submissions/detail/1086072489/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumCounts(IList<int> nums)
    {
        var n = nums.Count;
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var set = new HashSet<int>();

            for (var j = i; j < n; j++)
            {
                set.Add(nums[j]);
                ans += set.Count * set.Count;
            }
        }

        return ans;
    }
}
