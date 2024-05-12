using JetBrains.Annotations;

namespace LeetCode.Problems._0703_Kth_Largest_Element_in_a_Stream;

[PublicAPI]
public interface ISolution
{
    public IKthLargest Create(int k, int[] nums);
}
