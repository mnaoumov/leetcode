using JetBrains.Annotations;

namespace LeetCode._2660_Determine_the_Winner_of_a_Bowling_Game;

[PublicAPI]
public interface ISolution
{
    public int IsWinner(int[] player1, int[] player2);
}
