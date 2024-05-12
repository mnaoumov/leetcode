using JetBrains.Annotations;

namespace LeetCode.Problems._2834_Find_the_Minimum_Possible_Sum_of_a_Beautiful_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-360/submissions/detail/1032742886/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinimumPossibleSum(int n, int target)
    {
        var k = target / 2;
        return n <= k
            ? 1L * n * (n + 1) / 2
            : 1L * k * (k + 1) / 2 + 1L * (target + (target + n - k - 1)) * (n - k) / 2;
    }
}
