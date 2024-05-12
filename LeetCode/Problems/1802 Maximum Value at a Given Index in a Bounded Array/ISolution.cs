using JetBrains.Annotations;

namespace LeetCode.Problems._1802_Maximum_Value_at_a_Given_Index_in_a_Bounded_Array;

[PublicAPI]
public interface ISolution
{
    public int MaxValue(int n, int index, int maxSum);
}
