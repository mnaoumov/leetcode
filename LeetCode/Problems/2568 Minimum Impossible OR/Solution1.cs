using JetBrains.Annotations;

namespace LeetCode.Problems._2568_Minimum_Impossible_OR;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-98/submissions/detail/900410951/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinImpossibleOR(int[] nums)
    {
        var set = nums.ToHashSet();

        var powerOfTwo = 1;

        while (true)
        {
            if (!set.Contains(powerOfTwo))
            {
                return powerOfTwo;
            }

            powerOfTwo *= 2;
        }
    }
}
