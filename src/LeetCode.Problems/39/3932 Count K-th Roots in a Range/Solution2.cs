namespace LeetCode.Problems._3932_Count_K_th_Roots_in_a_Range;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-502/problems/count-k-th-roots-in-a-range/submissions/2005047980/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int CountKthRoots(int l, int r, int k)
    {
        var y = Math.Pow(r, 1d / k);
        var x = Math.Pow(l, 1d / k);

        var b = (int) Math.Floor(y);

        if (Math.Abs(Math.Pow(b + 1, k) - r) < double.Epsilon)
        {
            b++;
        }

        var a = (int) Math.Ceiling(x);

        if (Math.Abs(Math.Pow(a - 1, k) - l) < double.Epsilon)
        {
            a--;
        }

        return b - a + 1;
    }
}
