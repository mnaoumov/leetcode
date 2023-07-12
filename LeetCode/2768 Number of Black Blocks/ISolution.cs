using JetBrains.Annotations;

namespace LeetCode._2768_Number_of_Black_Blocks;

[PublicAPI]
public interface ISolution
{
    public long[] CountBlackBlocks(int m, int n, int[][] coordinates);
}
