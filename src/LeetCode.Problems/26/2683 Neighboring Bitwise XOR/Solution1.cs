namespace LeetCode.Problems._2683_Neighboring_Bitwise_XOR;

/// <seealso href="https://leetcode.com/contest/weekly-contest-345/submissions/detail/949925751/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool DoesValidArrayExist(int[] derived) => derived.Aggregate((result, current) => result ^ current) == 0;
}
