using JetBrains.Annotations;

namespace LeetCode._1630_Arithmetic_Subarrays;

[PublicAPI]
public interface ISolution
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r);
}
