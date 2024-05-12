using JetBrains.Annotations;

namespace LeetCode._2557_Maximum_Number_of_Integers_to_Choose_From_a_Range_II;

[PublicAPI]
public interface ISolution
{
    public int MaxCount(int[] banned, int n, long maxSum);
}
