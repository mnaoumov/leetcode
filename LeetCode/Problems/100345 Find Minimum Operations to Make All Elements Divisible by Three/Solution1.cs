using JetBrains.Annotations;

namespace LeetCode.Problems._100345_Find_Minimum_Operations_to_Make_All_Elements_Divisible_by_Three;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-133/submissions/detail/1296728067/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperations(int[] nums) => nums.Count(num => num % 3 != 0);
}
