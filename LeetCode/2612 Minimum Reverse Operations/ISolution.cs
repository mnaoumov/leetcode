using JetBrains.Annotations;

namespace LeetCode._2612_Minimum_Reverse_Operations;

[PublicAPI]
public interface ISolution
{
    public int[] MinReverseOperations(int n, int p, int[] banned, int k);
}
