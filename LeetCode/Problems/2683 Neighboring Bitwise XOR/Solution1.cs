using JetBrains.Annotations;

namespace LeetCode.Problems._2683_Neighboring_Bitwise_XOR;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-345/submissions/detail/949925751/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool DoesValidArrayExist(int[] derived) => derived.Aggregate((result, current) => result ^ current) == 0;
}
