using JetBrains.Annotations;

namespace LeetCode.Problems._2824_Count_Pairs_Whose_Sum_is_Less_than_Target;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-111/submissions/detail/1025768464/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPairs(IList<int> nums, int target)
    {
        var n = nums.Count;
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (nums[i] + nums[j] < target)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
