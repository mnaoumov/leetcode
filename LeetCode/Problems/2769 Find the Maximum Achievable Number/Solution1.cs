using JetBrains.Annotations;

namespace LeetCode.Problems._2769_Find_the_Maximum_Achievable_Number;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-353/submissions/detail/989740357/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TheMaximumAchievableX(int num, int t) => num + 2 * t;
}
