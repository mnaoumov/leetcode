namespace LeetCode.Problems._3178_Find_the_Child_Who_Has_the_Ball_After_K_Seconds;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-401/submissions/detail/1282247920/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfChild(int n, int k)
    {
        var fullCycle = 2 * (n - 1);
        k %= fullCycle;
        return Math.Min(k, fullCycle - k);
    }
}
