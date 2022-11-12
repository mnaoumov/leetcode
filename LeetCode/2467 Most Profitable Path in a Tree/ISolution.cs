using JetBrains.Annotations;

namespace LeetCode._2467_Most_Profitable_Path_in_a_Tree;

[PublicAPI]
public interface ISolution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount);
}
