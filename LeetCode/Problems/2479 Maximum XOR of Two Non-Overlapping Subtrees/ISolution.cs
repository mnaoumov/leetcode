using JetBrains.Annotations;

namespace LeetCode.Problems._2479_Maximum_XOR_of_Two_Non_Overlapping_Subtrees;

[PublicAPI]
public interface ISolution
{
    public long MaxXor(int n, int[][] edges, int[] values);
}
