namespace LeetCode.Problems._3746_Minimum_String_Length_After_Balanced_Removals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-476/problems/minimum-string-length-after-balanced-removals/submissions/1830846112/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinLengthAfterRemovals(string s)
    {
        var aCount = s.Count(letter => letter == 'a');
        var bCount = s.Length - aCount;
        return Math.Abs(aCount - bCount);
    }
}
