namespace LeetCode.Problems._2582_Pass_the_Pillow;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-335/submissions/detail/909222198/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PassThePillow(int n, int time)
    {
        var mod = time % (2 * n - 2);
        return mod < n ? mod + 1 : 2 * n - 1 - mod;
    }
}
