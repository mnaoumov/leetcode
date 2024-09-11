namespace LeetCode.Problems._1823_Find_the_Winner_of_the_Circular_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/941944678/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindTheWinner(int n, int k)
    {
        var ans = 1;

        for (var m = 2; m <= n; m++)
        {
            var removedIndex = ModUp(k, m);
            ans = ModUp(ans + removedIndex, m);
        }

        return ans;
    }

    private static int ModUp(int k, int m)
    {
        var remainder = k % m;
        return remainder == 0 ? m : remainder;
    }
}
