using JetBrains.Annotations;

namespace LeetCode.Problems._2554_Maximum_Number_of_Integers_to_Choose_From_a_Range_I;

[PublicAPI]
public interface ISolution
{
    public int MaxCount(int[] banned, int n, int maxSum);
}
