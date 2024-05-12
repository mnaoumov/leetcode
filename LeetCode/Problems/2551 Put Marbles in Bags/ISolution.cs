using JetBrains.Annotations;

namespace LeetCode.Problems._2551_Put_Marbles_in_Bags;

[PublicAPI]
public interface ISolution
{
    public long PutMarbles(int[] weights, int k);
}
