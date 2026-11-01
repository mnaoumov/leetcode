namespace LeetCode.Problems._2856_Minimum_Array_Length_After_Pair_Removals;

/// <seealso href="https://leetcode.com/contest/biweekly-contest-113/submissions/detail/1050998194/">Submission</seealso>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinLengthAfterRemovals(IList<int> nums)
    {
        var n = nums.Count;
        var i = 0;
        var ans = n;

        for (var j = (n + 1) / 2; j < n; j++)
        {
            if (nums[i] >= nums[j])
            {
                continue;
            }

            ans -= 2;
            i++;
        }

        return ans;
    }
}
