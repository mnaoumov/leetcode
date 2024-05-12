using JetBrains.Annotations;

namespace LeetCode._3028_Ant_on_the_Boundary;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-383/submissions/detail/1165392428/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ReturnToBoundaryCount(int[] nums)
    {
        var position = 0;
        var ans = 0;

        foreach (var num in nums)
        {
            position += num;

            if (position == 0)
            {
                ans++;
            }
        }

        return ans;
    }
}
