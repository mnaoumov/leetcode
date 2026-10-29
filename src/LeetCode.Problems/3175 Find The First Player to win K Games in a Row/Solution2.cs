namespace LeetCode.Problems._3175_Find_The_First_Player_to_win_K_Games_in_a_Row;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-132/submissions/detail/1281683633/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int FindWinningPlayer(int[] skills, int k)
    {
        var players = skills.Select((skill, index) => new Player(index, skill)).ToList();
        var mostSkilledPlayer = players.MaxBy(p => p.Skill)!;

        if (k >= mostSkilledPlayer.Index)
        {
            return mostSkilledPlayer.Index;
        }

        while (players[0].WinsCount != k)
        {
            var lostPlayerIndex = players[0].Skill < players[1].Skill ? 0 : 1;
            var lostPlayer = players[lostPlayerIndex];
            players.RemoveAt(lostPlayerIndex);
            players.Add(lostPlayer);
            players[0].WinsCount++;
        }

        return players[0].Index;
    }

    private record Player(int Index, int Skill)
    {
        public int WinsCount { get; set; }
    }
}
