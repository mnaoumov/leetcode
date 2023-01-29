using JetBrains.Annotations;

namespace LeetCode._1908_Game_of_Nim;

[PublicAPI]
public interface ISolution
{
    public bool NimGame(int[] piles);
}
