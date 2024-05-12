using JetBrains.Annotations;

namespace LeetCode._1535_Find_the_Winner_of_an_Array_Game;

[PublicAPI]
public interface ISolution
{
    public int GetWinner(int[] arr, int k);
}
