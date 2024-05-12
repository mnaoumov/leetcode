using JetBrains.Annotations;

namespace LeetCode._2682_Find_the_Losers_of_the_Circular_Game;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-345/submissions/detail/949919151/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] CircularGameLosers(int n, int k)
    {
        var losers = Enumerable.Range(2, n - 1).ToHashSet();

        var step = 1;
        var player = 1;

        while (true)
        {
            var nextPlayer = 1 + (player + step * k - 1) % n;

            if (!losers.Remove(nextPlayer))
            {
                return losers.OrderBy(x => x).ToArray();
            }

            player = nextPlayer;
            step++;
        }
    }
}
