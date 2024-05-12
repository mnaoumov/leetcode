using JetBrains.Annotations;

namespace LeetCode._2902_Count_of_Sub_Multisets_With_Bounded_Sum;

[PublicAPI]
public interface ISolution
{
    public int CountSubMultisets(IList<int> nums, int l, int r);
}
