using JetBrains.Annotations;

namespace LeetCode.Problems._3238_Find_the_Number_of_Winning_Players;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-136/submissions/detail/1343077458/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int WinningPlayerCount(int n, int[][] pick)
    {
        var counts = Enumerable.Range(0, n).Select(_ => new Dictionary<int, int>()).ToArray();

        var usersWon = new HashSet<int>();

        foreach (var p in pick)
        {
            var x = p[0];
            var y = p[1];

            if (usersWon.Contains(x))
            {
                continue;
            }

            counts[x].TryAdd(y, 0);
            counts[x][y]++;

            if (counts[x][y] > x)
            {
                usersWon.Add(x);
            }
        }

        return usersWon.Count;
    }
}
