using JetBrains.Annotations;

namespace LeetCode._10034_Find_Number_of_Coins_to_Place_in_Tree_Nodes;

[PublicAPI]
public interface ISolution
{
    public long[] PlacedCoins(int[][] edges, int[] cost);
}
