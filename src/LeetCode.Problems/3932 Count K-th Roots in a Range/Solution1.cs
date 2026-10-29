namespace LeetCode.Problems._3932_Count_K_th_Roots_in_a_Range;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-502/problems/count-k-th-roots-in-a-range/submissions/2005032154/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountKthRoots(int l, int r, int k) => (int) Math.Floor(Math.Pow(r, 1d / k)) - (int) Math.Ceiling(Math.Pow(l, 1d / k)) + 1;
}
